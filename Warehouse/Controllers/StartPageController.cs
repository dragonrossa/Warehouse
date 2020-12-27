using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;

namespace Warehouse.Controllers
{
    public class StartPageController : Controller
    {
        private WarehouseContext _db = new WarehouseContext();

        //Get StartPage Repository
        StartPageRepository startPageRepository = new StartPageRepository();

        // GET: StartPage
        public ActionResult Index()
        {

            try
            {
                
                if (startPageRepository.user(User.Identity.Name) == null)
                {
                    ViewBag.user = "new user";
                }
                else
                {
                    ViewBag.user = startPageRepository.user(User.Identity.Name).Name;

                    var user = User.Identity.Name;

                    var adminAccess = (from a in _db.AdminModels where a.Username == user select a).FirstOrDefault();

                    ViewBag.access = Convert.ToInt32(adminAccess.Access);
                    ViewBag.laptopAccess = Convert.ToInt32(adminAccess.LaptopAccess);
                    ViewBag.logAccess = Convert.ToInt32(adminAccess.LogAccess);
                    ViewBag.searchAccess = Convert.ToInt32(adminAccess.SearchAccess);
                    ViewBag.storeAccess = Convert.ToInt32(adminAccess.StoreAccess);
                    ViewBag.transferAccess = Convert.ToInt32(adminAccess.TransferAccess);
                    ViewBag.supplierAccess = Convert.ToInt32(adminAccess.SupplierAccess);
                    ViewBag.procurementAccess = Convert.ToInt32(adminAccess.ProcurementAccess);
                    ViewBag.taskAccess = Convert.ToInt32(adminAccess.TaskAccess);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
              
            }
          
            return View();
        }

        //Dispose DB
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}