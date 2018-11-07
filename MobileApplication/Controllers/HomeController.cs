using MobileApplication.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;


namespace MobileApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;


        public HomeController()
        {
            _context = new ApplicationDbContext(); ;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index(int? page, int manufacturers = 0, string search = "", int priceFrom = 0, int priceTo = int.MaxValue)
        {
            var mobiles = _context.Mobiles.Include(m => m.Manufacturer).ToList();

            var manufact = _context.Manufacturers.ToList();
            SelectList selectLists = new SelectList(manufact, "Id", "Name");
            ViewBag.sth = selectLists;


            if (manufacturers == 0)
            {
                var searchMobile = _context.Mobiles.Where(x => x.Name.Contains(search)).ToList();
                var priceOfMobileFrom = _context.Mobiles.Where(x => x.Price.CompareTo(priceFrom) == 1).ToList();
                var priceOfMobileTo = _context.Mobiles.Where(x => x.Price.CompareTo(priceTo) == -1).ToList();

                var commonPriceElements = priceOfMobileFrom.Intersect(priceOfMobileTo).ToList();
                var commonElements = commonPriceElements.Intersect(searchMobile).ToList();

                if (commonElements == null)
                    return View(mobiles);
                else
                    return View(commonElements.ToPagedList(page ?? 1, 7));
            }
            else
            {

                var searchMobile = _context.Mobiles.Where(x => x.Name.Contains(search)).ToList();
                var priceOfMobileFrom = _context.Mobiles.Where(x => x.Price.CompareTo(priceFrom) == 1).ToList();
                var priceOfMobileTo = _context.Mobiles.Where(x => x.Price.CompareTo(priceTo) == -1).ToList();
                var getManufacturer = _context.Mobiles.Where(x => x.ManufacturerId.Equals(manufacturers)).ToList();


                var commonPhoneFromManufacturers = getManufacturer.Intersect(searchMobile).ToList();
                var commonPriceElements = priceOfMobileFrom.Intersect(priceOfMobileTo).ToList();
                var commonElements = commonPriceElements.Intersect(commonPhoneFromManufacturers).ToList();

                if (commonElements == null)
                    return View(mobiles);
                else
                    return View(commonElements.ToPagedList(page ?? 1, 7));
            }
        }



        //public ViewResult Index()
        //{
        //    var data = _context.Manufacturers.ToList();
        //    SelectList selectLists = new SelectList(data, "Id", "Name");
        //    ViewBag.sth = selectLists;

        //    var mobiles = _context.Mobiles.Include(m => m.Manufacturer).ToList();
        //    return View(mobiles);
        //}


        public ActionResult Details(int id)
        {
            var mobiles = _context.Mobiles.Include(m => m.Manufacturer).SingleOrDefault(m => m.Id == id);
            if (mobiles == null)
                return HttpNotFound();

            return View(mobiles);
        }
    }
}