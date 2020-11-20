using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Models;

namespace Warehouse.Repository
{
     interface IProcurementRepository
    {
        //Get user
        UserModels username(string username);
        //Get Viewdata for computers
        object computers();

        //Create PDF document
        object createPdf(FormCollection form);
        //Download PDF file
        void downloadPDF();
    }
}