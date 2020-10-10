using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ComputerListController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ComputerList
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<ComputerListModels> computerListModels = new List<ComputerListModels>();
            computerListModels = (from c in _db.ComputerListModels select c).ToList();
            ViewData["Suppliers"] = _db.SupplierModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

            return View(computerListModels);
        }



        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form, ComputerListModels computerListModels, string [] Name)
        {
            //foreach(var computer in form)
            //{
            //    //int storeID = Convert.ToInt32(form["Suppliers"].ToString());
            //    computer.ToString();
            //}

            // int storeID = Convert.ToInt32(form["Suppliers"].ToString());

            //foreach(var item in form)
            //{
            //    item.ToString();
            //}

            //List[] =

            //foreach(var item in form["Suppliers"])
            //{
            //    item.ToString();
            //}

            //string[] suppliers;

            // var suppliers = Convert.ToString(form["Suppliers"]);


            //for (var i = 0; i < form.Count; i++)
            //{
            //    var supplier = form["Suppliers"][i].ToString();
            //    //var name = form["item.Name"][i].ToString();
            //}

            List<ComputerListModels> computerLists = (from c in _db.ComputerListModels select c).ToList();

            List<string> termsList = new List<string>();


           
            foreach(var i in form["Suppliers"])
            {
               
                if (!(i.ToString() == ","))
                {
                    
                
                        string supplier = i.ToString();

                          termsList.Add(supplier);


                }

                
            }

        
        

            var count = termsList.Count - computerLists.Count;

            termsList.RemoveAt(termsList.Count - count);


            for (int i = 1; i < termsList.Count; i++)
            {
                var compu = (from c in _db.ComputerListModels where c.ID==i select c).FirstOrDefault();
                compu.SupplierID = termsList[i];
                _db.SaveChanges();
            }
            


            

            string name = form["item.Name"];
            var store = form["Suppliers"];           

             return RedirectToAction("Index");

        }
    }
}