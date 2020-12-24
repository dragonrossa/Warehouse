using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public abstract class DatabaseRepository:IDatabaseRepository
    {
        private WarehouseContext _db = new WarehouseContext();
      //  private TransferModels transfer;

        //Get DB
        public WarehouseContext Data(WarehouseContext _db)
        {

            this._db = _db;
            return _db;
        }


        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

    }
}