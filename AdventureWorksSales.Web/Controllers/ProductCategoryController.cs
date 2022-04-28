using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Models.data;

namespace AdventureWorksSales.Web.Controllers
{
    [Guid("6DF77A62-4B51-4A50-B10C-47FBAC932F32")]
    public class ProductCategoryController : Controller
    {
        readonly AdventuresDbContext db = new AdventuresDbContext();



        public ActionResult Index()
        {
            //List<ProductCategoryView> pclist = new List<ProductCategoryView>();
            var pclist = from d in db.ProductCategories
                         select new ProductCategoryView
                         {
                             ModifiedDate = d.ModifiedDate,
                             Name = d.Name,
                             ProductCategoryID = d.ProductCategoryID,
                             Rowguid = d.rowguid
                         };
            return View(pclist);
        }



        public ActionResult Create()
        {
            var pc = new ProductCategoryView
            {
                Rowguid = Guid.NewGuid()
            };

            return View(pc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoryView productCategory)
        {
            if (ModelState.IsValid)
            {
                var pc = new ProductCategory
                {
                    ModifiedDate = productCategory.ModifiedDate,
                    Name = productCategory.Name,
                    rowguid = productCategory.Rowguid,
                    ProductCategoryID    = productCategory.ProductCategoryID
                };
                db.ProductCategories.Add(pc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productCategory = db.ProductCategories.Where(x => x.ProductCategoryID == id).FirstOrDefault();
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            var result = new ProductCategoryView();
            result.Name = productCategory.Name;
            result.Rowguid = productCategory.rowguid;
            result.ProductCategoryID = productCategory.ProductCategoryID;

           
            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryID,Name,rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
