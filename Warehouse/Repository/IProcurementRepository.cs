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
        object createPdf(FormCollection form, string path);

        //Get computer name
        object getComputerPDF(FormCollection form);

        //Get computer quantity

        object getComputerQuantity(FormCollection form);

        //Get date
        object getDate();

        //Get invoice numbere
        object getInvoiceNo();

        //Get current invoice number
        object getInvoiceNo2();

        //Get PDFFileName
        object getPDFFileName(string getInvoiceNO);

        
    }
}