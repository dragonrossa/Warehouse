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

namespace Warehouse.Controllers
{
    public class ProcurementController : Controller
    {
        //Get DB Context
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Get Procurement Repository

        ProcurementRepository procurementRepository = new ProcurementRepository();

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

        //// GET: Procurement
        public ActionResult CreateInvoice()
        {

            try
            {
                //Find user
                ViewBag.user = procurementRepository.username(User.Identity.Name);

                //ViewData computers
                ViewData["computers"] = procurementRepository.computers();

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
            string path = Server.MapPath("~/PDFFiles/");
            procurementRepository.createPdf(form, path);
            //Get computer name
            TempData["computer"] = procurementRepository.getComputerPDF(form);
            //Get computer quantity
            TempData["quantity"] = procurementRepository.getComputerQuantity(form);
            //Get date
            TempData["date"] = procurementRepository.getDate();
            //Get invoice number
            TempData["invoiceNo"] = procurementRepository.getInvoiceNo2();
            //Get pdfFileName
            TempData["pdfFilename"] = procurementRepository.getPDFFileName(procurementRepository.getInvoiceNo2().ToString());

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