using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.ViewModel
{
    public class MobileManufacturerViewModel
    {
        public Mobile Mobile { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}