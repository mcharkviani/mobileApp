using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public string ScreenSize { get; set; }
        public string Resolution { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string OS { get; set; }
        public int Price { get; set; }
        public string Features { get; set; }
        public string Video { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public string Link { get; set; }
    }
}