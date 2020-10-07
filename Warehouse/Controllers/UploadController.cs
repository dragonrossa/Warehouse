using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class UploadController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
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


    }
}