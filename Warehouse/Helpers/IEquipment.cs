using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Warehouse.Models;

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
    interface ListOrderByLaptop<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }
        List<T> AscendingByQuantity { get; }
        List<T> DescendingByQuantity { get; }
        List<T> AscendingByPrice { get; }
        List<T> DescendingByPrice { get; }

        List<T> AscendingByFullPrice { get; }
        List<T> DescendingByFullPrice { get; }

        List<T> AscendingByOS { get; }
        List<T> DescendingByOS { get; }

    }


    //Interface for StoreModels - sorting out
    interface ListOrderbyStore<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }
        List<T> AscendingByLocation { get; }
        List<T> DescendingByLocation { get; }
        List<T> AscendingByZipcode { get; }
        List<T> DescendingByZipcode { get; }
        List<T> AscendingByQuantityOfProducts { get; }
        List<T> DescendingByQuantityOfProducts { get; }
    }

    //Interface for TransferModels - sorting out
    interface ListOrderbyTransfer<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }
        List<T> AscendingByQuantity { get; }
        List<T> DescendingByQuantity{ get; }
        List<T> AscendingByPlace { get; }
        List<T> DescendingByPlace { get; }
    }

    //Interface for TaskListModels - sosting out

    interface ListOrderByTask<T>
    {
        List<T> AscendingByID { get; }
        List<T> DescendingByID { get; }
        List<T> AscendingByStatus { get; }
        List<T> DescendingByStatus { get; }
    }

    //Interface for LogModels - sorting out

    interface ListOrderByLog<T>
    {
        List<T> AscendingByDate { get; }
        List<T> DescendingByDate { get; }
    }

  
    //Interface for UserModels - sorting out

    interface ListOrderByUser<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }

        List<T> AscendingByLastName { get; }
        List<T> DescendingByLastName { get; }
        List<T> AscendingByUserName { get; }
        List<T> DescendingByUserName { get; }
    }

    //Interface for ComputerList - sorting out

    interface ListOrderByComputerList<T>
    {
        List<T> AscendingByName { get; }
        List<T> DescendingByName { get; }
    }


     abstract class User<T>
    {
        public abstract List<T> Child { get; }
        public abstract List<T> Ascending { get; }
        public abstract List<T> Descending { get; }
    }


}