using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Helpers
{
    public class CustomExceptions
    {

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base() { }
            public UserNotFoundException(string message) : base(message) { }
            public UserNotFoundException(string message, Exception innerException)
                : base(message, innerException) { }
        }


    }
}