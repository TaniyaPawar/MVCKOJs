using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKO.Models;
using System.Data.Entity;
using System.Net;

namespace MVCKO.Controllers
{
    public class ProductSoldController : Controller
    {
        private KOModel db = new KOModel();
        // GET: ProductSold
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductSolds()
        {
            var productSolds = (from p in db.KOProductsSold
                                select p).ToList()
                                .Select(p => new KOProductSold
                                {
                                    //these are the properties
                                    ID = p.ID,
                                    DateSold = p.DateSold,
                                    ProductId = p.ProductId,
                                    CustomerId = p.CustomerId,
                                    StoreId = p.StoreId,
                                    ProductName = p.ProductName
                                    //CustomerName = p.KOCustomer.CustomerName,
                                    //StoreName = p.KOStore.StoreName
                                });
            return Json(productSolds, JsonRequestBehavior.AllowGet);
        }

        //get KOProductsSold/Details
        public ActionResult Details()
        {
            return PartialView();
        }

        //get KOProductsSold/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.KOProducts, "ID", "Name");
            return PartialView();
        }

        //post KOProductsSold/Create
        // to protect from overposting attacks, please enable the specific properties you want to bind to, for
        //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public long Create([Bind(Include = "DateSold,ProductId,CustomerId,StoreId")] KOProductSold productSold)
        public long Create([Bind(Include = "ID,DateSold,ProductId,ProductName")] KOProductSold productSold)
        {
            long id = 0;
            if (ModelState.IsValid)
            {
                db.KOProductsSold.Add(productSold);
                db.SaveChanges();
                return productSold.ID;
            }
            return id;
        }

        //get KOProductSold/Edit
        public ActionResult Edit()
        {
            ViewBag.ProductId = new SelectList(db.KOProducts, "ID", "Name");
            return PartialView();
        }

        //post KOProductSold/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,DateSold,ProductId,CustomerId,StoreId")] KOProductSold productSold)
        public ActionResult Edit([Bind(Include = "ID,DateSold,ProductId,ProductName")] KOProductSold productSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSold).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(200, "Success");
            }
            return new HttpStatusCodeResult(404, "Unable to update.");
        }

        //get KOProductSold/Delete
        public ActionResult Delete()
        {
            return PartialView();
        }

        //post KOProductSold/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                KOProductSold KOProductSold = db.KOProductsSold.Find(id);
                db.KOProductsSold.Remove(KOProductSold);
                db.SaveChanges();
                return new HttpStatusCodeResult(200, "Success");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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