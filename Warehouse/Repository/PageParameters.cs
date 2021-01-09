using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Repository
{
    public class PageParameters
    {
        //Add pageSize

        public int _pageSize;


        public int pageSize
        {
            get
            {
                this._pageSize = 10;
                return this._pageSize;
            }


        }

        //Add pageNumber


        public int pageNumber(int? page)
        {

            return page ?? 1;

        }
    }
}