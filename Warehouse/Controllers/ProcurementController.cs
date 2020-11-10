﻿using Microsoft.Owin.Security.Provider;
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

namespace Warehouse.Controllers
{
    public class ProcurementController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Procurement


        //Get username
        public UserModels username()
        {
            var username = User.Identity.Name;
            var user = (from u in _db.UserModels where u.UserName == username select u).FirstOrDefault();
            return user;
        }


        //Get Viewdata for computers
        public object computers()
        {
            return ViewData["computers"] = _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();
            
        }

        //Create PDF document

        public object createPdf(FormCollection form)
        {
            int laptopID = Convert.ToInt32(form["computers"]);

            var laptopName = (from l in _db.ComputerListModels where l.ID == laptopID select l.Name).FirstOrDefault();

            var quantity = Convert.ToInt32(form["Quantity"]);

            TempData["quantity"] = quantity;
            TempData["computer"] = laptopName;
            TempData["date"] = DateTime.Now;

            int? id = (from p in _db.ProcurementModels orderby p.ID descending select p.ID).FirstOrDefault();

            if (id == null)
            {
                id = 0;
            }


            string invoiceNo = "0000" + id;

            TempData["invoiceNo"] = invoiceNo;

            ProcurementModels procurement = new ProcurementModels()
            {
                Computer = laptopName.ToString(),
                Quantity = quantity,
                InvoiceNo = invoiceNo,
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
            string path = Server.MapPath("~/PDFFiles/");

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


            pdf.Save(path + pdfFilename);
            //TempData for DownloadPDF
            TempData["pdfFilename"] = pdfFilename;

            return TempData["pdfFilename"];
        }

        //Download PDF file
        void downloadPDF()
        {
            var pdfFilename = TempData["pdfFilename"];

            //Clear all
            Response.Clear();
            Response.ClearContent();    
            Response.ClearHeaders();

            //Find PDF Files in particular folder and send response to user
            Response.ContentType = "Application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", pdfFilename));
            Response.TransmitFile(Server.MapPath("~/PDFFiles/" + pdfFilename));

            Response.End();
            Response.Flush();
        }

        public ActionResult CreateInvoice()
        {

            try
            {
                //Find user
                ViewBag.user = username().Name;

                //ViewData computers
                computers();

                return View();
            }
            catch (Exception e)
            {

                //redirect if there are no Laptopmodels in list
                if (e.Message == "Sequence contains no elements")
                {

                    //throw new UserNotFoundException();
                    // throw;
                    return RedirectToAction("NotFound");

                }

            }
            return View();
        }




        //Exception - UserNotFound

        public ActionResult NotFound()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInvoice(FormCollection form)
        {
            //Create PDF
            createPdf(form);

            return RedirectToAction("DownloadInvoice");
        }

        public ActionResult DownloadInvoice()
        {


            ViewBag.invoiceNo = TempData["invoiceNo"];
            ViewBag.quantity = TempData["quantity"];
            ViewBag.computer = TempData["computer"];
            ViewBag.date = TempData["date"];

            return View();
        }

        [HttpPost]
        public ActionResult DownloadInvoiceNo()
        {
            //Download PDF 
            downloadPDF();
            return View();
        }
        
    }
}