using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.Repository
{
    public abstract class DatabaseRepository:IDatabaseRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
      //  private TransferModels transfer;

        //Get DB
        public ApplicationDbContext Data(ApplicationDbContext _db)
        {

            this._db = _db;
            return _db;
        }

        //Add to database - override if neccesary
        public void addToDatabase(TransferModels transfer)
        {
            _db.TransferModels.Add(transfer);
        }


        //Save DB
        public object SaveData()
        {

            return _db.SaveChanges();
        }

    }
}