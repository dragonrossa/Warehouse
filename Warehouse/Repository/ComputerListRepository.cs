using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class ComputerListRepository:IComputerListRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        ComputerListModels computer = new ComputerListModels();

        //Get DB
        public ApplicationDbContext Data(ApplicationDbContext _db)
        {

            this._db = _db;
            return _db;
        }


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
        public string[] computers(FormCollection form)
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


        //After change save all records
        public string[] saveAllRecords(FormCollection form)
        {
            var computerName = form["item.Name"].ToString();
            string[] computers = computerName.Split(',');


            string supplierName = form["SupplierName"].ToString();
            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string comp;
            string supName;
            int supi;


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

            return computers;
        }


        //Return classic view for Computers and Suppliers
        public ComputerListModels getClassicViewSuppliers(FormCollection form)
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

            return computerLists;
        }

        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }
    }
}