using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Net;
using System.IO;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Warehouse.Repository;
using Warehouse.DAL;

namespace Warehouse.Repository
{
    public class ProcurementRepository: Controller, IProcurementRepository 
    {
        private WarehouseContext _db = new WarehouseContext();
        // GET: Procurement

        //Get username
        public UserModels username(string username)
        {
            var user = (from u in _db.UserModels where u.UserName == username select u).FirstOrDefault();
            return user;
        }


        //Get Viewdata for computers
        public object computers()
        {
            return _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Get computer name
        public object getComputerPDF(FormCollection form)
        {
            int laptopID = Convert.ToInt32(form["computers"]);
            var laptopName = (from l in _db.ComputerListModels where l.ID == laptopID select l.Name).FirstOrDefault();
            TempData["computer"] = laptopName;
            return TempData["computer"];
        }

        //Get computer quantity

        public object getComputerQuantity(FormCollection form)
        {
            var quantity = Convert.ToInt32(form["Quantity"]);

            TempData["quantity"] = quantity;
            return TempData["quantity"];
        }

        //Get date
        public object getDate()
        {
            TempData["date"] = DateTime.Now;
            return TempData["date"];
        }

        //Get invoice numbere
        public object getInvoiceNo()
        {
            int? id = (from p in _db.ProcurementModels orderby p.ID descending select p.ID).FirstOrDefault();

            if (id == null)
            {
                id = 0;
            }

            id = id + 1;


            string invoiceNo = "0000" + id;

            TempData["invoiceNo"] = invoiceNo;

            return TempData["invoiceNo"];
        }

        //Get current invoice number

        public object getInvoiceNo2()
        {
            int? id = (from p in _db.ProcurementModels orderby p.ID descending select p.ID).FirstOrDefault();
            string invoiceNo = "0000" + id;

            TempData["invoiceNo"] = invoiceNo;

            return TempData["invoiceNo"];
        }

        //Get PDFFileName
        public object getPDFFileName(string getInvoiceNO)
        {
            string pdfFilename = "Invoice_" + getInvoiceNO + ".pdf";
            TempData["pdfFilename"] = pdfFilename;
            return TempData["pdfFilename"];
        }

        //Create PDF document

        public object createPdf(FormCollection form, string path)
        {
           
            //Create new procurement object 

            ProcurementModels procurement = new ProcurementModels()
            {
                Computer = getComputerPDF(form).ToString(),
                Quantity = Convert.ToInt32(getComputerQuantity(form)),
                InvoiceNo = getInvoiceNo().ToString(),
                RequestDate = DateTime.Today
            };

            _db.ProcurementModels.Add(procurement);
            _db.SaveChanges();

            var supplier = (from c in _db.ComputerListModels where c.Name == procurement.Computer select c.SupplierName).FirstOrDefault();
            ViewBag.supplier = supplier;

            //Create Invoice PDF

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = procurement.InvoiceNo;
            PdfPage pdfPage = pdf.AddPage();
            string pdfFilename = "Invoice_" + procurement.InvoiceNo + ".pdf";

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 20, XFontStyle.Bold);

            graph.DrawString("New procurement request", font2,
                XBrushes.Black,
                new XRect(50, 50, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("Supplier: " + supplier, font,
                XBrushes.Black,
                new XRect(50, 100, 200, 0), XStringFormats.TopLeft);

            graph.DrawString(pdfFilename, font,
                XBrushes.Black,
                new XRect(50, 130, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("Quantity: " + procurement.Quantity, font,
                  XBrushes.Black,
                new XRect(50, 160, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("Computer: " + procurement.Computer, font,
                  XBrushes.Black,
                new XRect(50, 190, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("This request was made on " + procurement.RequestDate, font,
                XBrushes.Black,
                new XRect(50, 220, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("Signature ", font,
              XBrushes.Black,
              new XRect(50, 250, 200, 0), XStringFormats.TopLeft);

            graph.DrawString("___________________", font,
              XBrushes.Black,
              new XRect(50, 280, 200, 0), XStringFormats.TopLeft);


            pdf.Save(path + getPDFFileName(procurement.InvoiceNo));

            //TempData for DownloadPDF
            TempData["pdfFilename"] = getPDFFileName(procurement.InvoiceNo);
            return TempData["pdfFilename"];
        }
        
    }
}