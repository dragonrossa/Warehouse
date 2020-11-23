using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
    interface ISupplierRepository
    {

        //Create Supplier
        SupplierModels newSupplier(SupplierModels supplier);
        //Edit Supplier
        void editSupplier(FormCollection form);
        //Delete Supplier
        void deleteSupplier(int? id);
    }
}