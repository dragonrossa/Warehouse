﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;
using System.Data.Entity;
using Warehouse.DAL;
using PagedList;

namespace Warehouse.Repository
{
    public class ComputerListRepository:Controller, IComputerListRepository
    {
        //Get DB Context
        private WarehouseContext _db = new WarehouseContext();

        //Get ComputerListModels object

        ComputerListModels computer = new ComputerListModels();

        //Get PageParameters object

        PageParameters pages = new PageParameters();

        //Get List

        List<ComputerListModels> computersList = new List<ComputerListModels>();

        //Get List

        List<SupplierModels> suppliersList = new List<SupplierModels>();

        //Get DB
        public WarehouseContext Data(WarehouseContext _db)
        {

            this._db = _db;
            return _db;
        }


        //Return List of computers
        public async Task<List<ComputerListModels>> computerLists()
        {
            return await (from c in _db.ComputerListModels select c).ToListAsync();
        }

        //Return List of computers
        public async Task<List<SupplierModels>> supplierLists()
        {
            return await (from c in _db.SupplierModels select c).ToListAsync();
        }


        //List of suppliers
        public async Task<List<SelectListItem>> suppliers()
        {
            var list = _db.SupplierModels.Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            });

            return await list.ToListAsync();
        }

        //Select list for all computers

        public async Task<List<SelectListItem>> computers()
        {
            var list = _db.ComputerListModels.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });

            return await list.ToListAsync();
        }

        //Select list for all suppliers
        public async Task<List<SelectListItem>> suppliersforClassicView()
        {
            var list = _db.SupplierModels.Select(u => new SelectListItem
            {
                Text = u.SupplierName,
                Value = u.ID.ToString()
            });

            return await list.ToListAsync();

        }


        //Create new Computer
        public async Task<ComputerListModels> createNewComputer(FormCollection form)
        {
            computer.Name = form["Name"]; ;
            computer.Date = DateTime.Now;

            _db.ComputerListModels.Add(computer);
            await _db.SaveChangesAsync();

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

            string supplierName = form["suppliers"].ToString();
            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return sup;
        }


        //After change save all records
        public async Task<string[]> saveAllRecords(FormCollection form)
        {
            var computerName = form["item.Name"].ToString();
            string[] computers = computerName.Split(',');


            string supplierName = form["suppliers"].ToString();
            string[] sup = supplierName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            string comp;
            string supName;
            int supi;


            for (int i = 0; i < computers.Length; i++)
            {
                comp = computers[i];
                supName = sup[i];
                supi = Convert.ToInt32(supName);
                var computerFind = await (from c in _db.ComputerListModels where c.Name == comp select c).FirstOrDefaultAsync();
                var suppliersName = await (from s in _db.SupplierModels where s.ID == supi select s).FirstOrDefaultAsync();
                computerFind.SupplierID = Convert.ToInt32(supName);
                computerFind.SupplierName = suppliersName.SupplierName;
                await _db.SaveChangesAsync();
            }

            return computers;
        }


        //Return classic view for Computers and Suppliers
        public async Task<ComputerListModels> getClassicViewSuppliers(FormCollection form)
        {
            var computerName = form["Name"].ToString();
            var supplierName = form["suppliers"].ToString();


            int cName = Convert.ToInt32(computerName.Remove(computerName.Length - 1));
            int sName = Convert.ToInt32(supplierName.Remove(supplierName.Length - 1));


            ComputerListModels computerLists = await (from e in _db.ComputerListModels
                                                where e.ID == cName
                                                select e).FirstOrDefaultAsync();

            var supplier = await(from e in _db.SupplierModels
                            where e.ID == sName
                            select e).FirstOrDefaultAsync();

            computerLists.SupplierID = sName;
            computerLists.SupplierName = supplier.SupplierName;

            await _db.SaveChangesAsync();

            return computerLists;
        }


        //Search and Paging

        public async Task<object> pageCount(int pageSize)
        {
            int pageCount = computer.Child.Count();
            int pages = pageCount / pageSize;
            ViewBag.pageCount = pages;
            int rest = pageCount % pageSize;
            if (rest < 10)
            {
                pages = pages + 1;
                ViewBag.pageCount = pages;
            }
            return ViewBag.pageCount;
        }

        //Get IPagedList for View

        public async Task<IPagedList<ComputerListModels>> pagedComputerList(int? page)
        {
            computersList = await computerLists();
            return computersList.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        public async Task<IPagedList<SupplierModels>> pagedSupplierList(int? page)
        {
            suppliersList = await supplierLists();
            return suppliersList.ToPagedList(pages.pageNumber(page), pages.pageSize);

        }

        //Get IPagedList for Search
        public async Task<IPagedList<ComputerListModels>> userSearch(int? page, string searchString)
        {
            computersList = await computerLists();
            computersList = computersList.Where(s => s.Name.Contains(searchString)).ToList();
            return computersList.ToPagedList(pages.pageNumber(page), pages.pageSize);
        }



        //Save DB
        public async Task<object> SaveData()
        {

            return await _db.SaveChangesAsync();
        }
    }
}