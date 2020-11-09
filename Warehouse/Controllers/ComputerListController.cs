using Microsoft.Ajax.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ComputerListController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        ComputerListModels computer = new ComputerListModels();


        //Return List of computers
        public List<ComputerListModels> computerLists()
        {
            return (from c in _db.ComputerListModels select c).ToList();
        }


        //List of suppliers
        public List<SelectListItem> suppliers()
        {
            return _db.SupplierModels.ToList().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Select list for all computers

        public List<SelectListItem> computers()
        {
            return _db.ComputerListModels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            }).ToList();

        }

        //Select list for all suppliers
        public List<SelectListItem> suppliersforClassicView()
        {
            return _db.SupplierModels.ToList().Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            }).ToList();
        }


        //Create new Computer
        public ComputerListModels createNewComputer(FormCollection form)
        {
            computer.Name = form["Name"]; ;
            computer.Date = DateTime.Now;

            _db.ComputerListModels.Add(computer);
            _db.SaveChanges();

            return computer;

        }

        //List of computers on Index page
        public string [] computers(FormCollection form)
        {
            var computerName = form["item.Name"].ToString();
            string[] computers = computerName.Split(',');
            return computers;

        }

        //List of suppliers on Index page

        public string[] suppliers(FormCollection form)
        {

            string supplierName = form["SupplierName"].ToString();
            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return sup;
        }



        // GET: ComputerList
        [HandleError]
        public ActionResult Index()
        {


            try
            {


                return View(new ComputerListModels() { suppliers = suppliers(), computersList = computerLists() });
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
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            if(form.Count <= 1)
            {
                return RedirectToAction("Index", "Supplier");
            }


            if (form["item.Name"].ToString() == null)
            {
                return RedirectToAction("Create", "ComputerList");
            }

            if (form["SupplierName"].ToString() == null)
            {
                return RedirectToAction("Index", "Supplier");
            }


            var computerName = form["item.Name"].ToString();
            string[] computers = computerName.Split(',');
            

            string supplierName = form["SupplierName"].ToString();
            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string comp;
            string supName;
            int supi;


            if (sup == null || sup.Length == 0)
            {
                return RedirectToAction("Index", "Supplier");
            }
               

            for (int i = 0; i < computers.Length; i++)
            {
                comp = computers[i];
                supName = sup[i];
                supi = Convert.ToInt32(supName);
                var computerFind = (from c in _db.ComputerListModels where c.Name == comp select c).FirstOrDefault();
                var suppliersName = (from s in _db.SupplierModels where s.ID == supi select s).FirstOrDefault();
                computerFind.SupplierID = Convert.ToInt32(supName);
                computerFind.SupplierName = suppliersName.SupplierName;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }




        public ActionResult ClassicView()
        {


            return View(new ComputerListModels() { suppliers = suppliersforClassicView(), computers = computers() });
        }


        [HttpPost]
        public ActionResult ClassicView(FormCollection form)
        {
            var computerName = form["Name"].ToString();
            var supplierName = form["SupplierName"].ToString();



            int cName = Convert.ToInt32(computerName.Remove(computerName.Length - 1));
            int sName = Convert.ToInt32(supplierName.Remove(supplierName.Length - 1));


            ComputerListModels computerLists = (from e in _db.ComputerListModels
                                                where e.ID == cName
                                                select e).FirstOrDefault();

            var supplier = (from e in _db.SupplierModels
                            where e.ID == sName
                            select e).FirstOrDefault();

            computerLists.SupplierID = sName;
            computerLists.SupplierName = supplier.SupplierName;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }




        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]

        public ActionResult Create(FormCollection form)
        {
            
            //Create new Computer object

            createNewComputer(form);

            return RedirectToAction("Index");
        }




    }
}  