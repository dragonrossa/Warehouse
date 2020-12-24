using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public class SupplierRepository: Controller, ISupplierRepository
    {
        private WarehouseContext _db = new WarehouseContext();

        //Create Supplier
        public SupplierModels newSupplier(SupplierModels supplier)
        {

            if (ModelState.IsValid)
            {
                _db.SupplierModels.Add(supplier);
                _db.SaveChanges();
            }

            return supplier;
        }



        //Edit Supplier
        public void editSupplier(FormCollection form)
        {
            var supplierName = form["item.SupplierName"];
            var location = form["item.Location"];
            string[] suppliers = supplierName.Split(',');
            string[] suppliersLocation = location.Split(',');

            string supName;

            for (int i = 0; i < suppliers.Length; i++)
            {
                supName = suppliers[i];
                var suppliers1 = (from s in _db.SupplierModels where s.SupplierName == supName select s).FirstOrDefault();
                suppliers1.SupplierName = suppliers[i];
                suppliers1.Location = suppliersLocation[i];
                _db.SaveChanges();
            }

        }

        //Delete Supplier
        public void deleteSupplier(int? id)
        {

            var supplier = (from s in _db.SupplierModels
                            where s.ID == id
                            select s).FirstOrDefault();

            _db.SupplierModels.Remove(supplier);
            _db.SaveChanges();
        }

    }
}