using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Models.data;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly AdventuresDbContext db = new AdventuresDbContext();
        public ActionResult Index()
        {
            var summary = new SalesSummary
            {
                TotalOrders = (double)db.SalesOrders.Count(),

                HighestLineTotal = db
                                        .SalesOrders
                                        .OrderByDescending(x => x.LineTotal)
                                        .FirstOrDefault().LineTotal,
                //948 == frontbrakes
                FrontBrakesTotal = db
                                        .SalesOrders
                                        .Where(p => p.ProductID == 948)
                                        .Sum(x => x.LineTotal)
            };
            return View(summary);
        }

    }
}