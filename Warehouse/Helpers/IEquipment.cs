using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Helpers
{
    // Interface for Equipment
    interface IEquipment
    {

        [Key]
        int ID { get; set; }

        string Name { get; set; }

        string Details { get; set; }
        int Quantity { get; set; }

    }

    //Interface for various Lists

    interface IElement<T>
    {
        List<T> Child { get; }
        List<T> Ascending { get; }
        List<T> Descending { get; }
    }


    //Interface for Suppliers


    interface ISupplier
    {
        int ID { get; set; }
        string SupplierAddress { get; set; }

        string SupplierLocation { get; set; }
    }



    //Interface for LaptopModels - sorting out
    interface ListOrderBy<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }
        List<T> AscendingByQuantity { get; }
        List<T> DescendingByQuantity { get; }
        List<T> AscendingByPrice { get; }
        List<T> DescendingByPrice { get; }

        List<T> AscendingByFullPrice { get; }
        List<T> DescendingByFullPrice { get; }

    }


}