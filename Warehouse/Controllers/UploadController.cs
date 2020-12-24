using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Web.UI.WebControls;
using Warehouse.Helpers;
using System.Diagnostics;
using Warehouse.Repository;
using Warehouse.DAL;

namespace Warehouse.Controllers
{
    public class UploadController : Controller
    {
        WarehouseContext _db = new WarehouseContext();
        // GET: Upload
        
        public ActionResult Index()
        {
            
            List<UploadModels> uploadModels = new List<UploadModels>();
            uploadModels = _db.UploadModels.ToList();
            return View(uploadModels);
        }

        // POST: Upload

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
               
            }

            UploadModels uploadModels = new UploadModels();
            var str = System.Text.Encoding.Default.GetString(bytes);

            uploadModels.Name = postedFile.FileName;
            uploadModels.ContentType = postedFile.ContentType;
            uploadModels.Data = str;
            uploadModels.test = bytes;

            _db.UploadModels.Add(uploadModels);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [HandleError]
        public FileResult DownloadFile(int? FileId)
        {
            UploadModels uploadModels = new UploadModels();
            var file = _db.UploadModels.ToList().Find(p => p.ID == FileId);
            return File(file.test, file.ContentType, file.Name);
        }

        public ActionResult CreateNewPdf()
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "My First PDF";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            graph.DrawString("This is my first PDF document", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            string pdfFilename = "firstpage.pdf";
            string path = Server.MapPath("~/PDFFiles/");
            pdf.Save(path+pdfFilename);

            return View();
        }

        public ActionResult ModalPopUp()
        {

           
            //List<UserModels> users = _db.UserModels.ToList().Select(u => new UserModels
            //{
            //    ID = u.ID,
            //    Name = u.Name + " " + u.LastName,
            //    UserName = u.UserName,
            //    Address = u.Address,
            //    ZipCode = u.ZipCode,
            //    Country = u.Country,
            //    Telephone = u.Telephone,
            //    Hometown = u.Hometown,
            //    Mail = u.Mail
            //}).ToList();


            List<UserModels> users = _db.UserModels.ToList().OrderBy(u=>u.ID).Select(u => new UserModels
            {
                ID = u.ID,
                Name = u.Name + " " + u.LastName,
                UserName = u.UserName,
                Address = u.Address,
                ZipCode = u.ZipCode,
                Country = u.Country,
                Telephone = u.Telephone,
                Hometown = u.Hometown,
                Mail = u.Mail
            }).ToList();




            return View( new UserModels() { users = users });
        }

        public ActionResult NewPartner()
        {

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult NewPartner(UserModels user)
        {
            if (ModelState.IsValid)
            {
                _db.UserModels.Add(user);
                _db.SaveChanges();
                return RedirectToAction("ModalPopUp");
            }
            return View(user);
        }


    
        public ActionResult DescModal()
        {

            List<UserModels> users = _db.UserModels.ToList().OrderByDescending(u => u.Name).Select(u => new UserModels
            {
                ID = u.ID,
                Name = u.Name + " " + u.LastName,
                UserName = u.UserName,
                Address = u.Address,
                ZipCode = u.ZipCode,
                Country = u.Country,
                Telephone = u.Telephone,
                Hometown = u.Hometown,
                Mail = u.Mail
            }).ToList();
            return View("ModalPopUp", new UserModels() { users = users });
        }

        public ActionResult AscModal()
        {

            List<UserModels> users = _db.UserModels.ToList().OrderBy(u => u.Name).Select(u => new UserModels
            {
                ID = u.ID,
                Name = u.Name + " " + u.LastName,
                UserName = u.UserName,
                Address = u.Address,
                ZipCode = u.ZipCode,
                Country = u.Country,
                Telephone = u.Telephone,
                Hometown = u.Hometown,
                Mail = u.Mail
            }).ToList();
            return View("ModalPopUp", new UserModels() { users = users });
        }

        public ActionResult Error()
        {
            return View();
        }


    }
}