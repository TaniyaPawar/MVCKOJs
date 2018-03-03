using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCKO.Models;

namespace MVCKO.Controllers
{
    public class ProductController : Controller
    {
        private KOModel db = new KOModel();

        // GET: KOProducts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            var products = (from ru in db.KOProducts
                            select ru).ToList()
                           .Select(ru => new KOProduct
                           {
                               ID = ru.ID,
                               Name = ru.Name,
                               Price = ru.Price
                           });

            //var products = db.KOProducts.Select(p => new KOProduct
            //{
            //    ID = p.ID,
            //    Name = p.Name,
            //    Price = p.Price
            //});
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // GET: KOProducts/Details/5
        public ActionResult Details()
        {
            return PartialView();
        }

        // GET: KOProducts/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: KOProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public long Create([Bind(Include = "ID,Name,Price")] KOProduct product)
        {
            long id = 0;
            if (ModelState.IsValid)
            {
                db.KOProducts.Add(product);
                db.SaveChanges();
                return product.ID;
            }

            return id;
        }

        // GET: KOProducts/Edit/5
        public ActionResult Edit()
        {
            return PartialView();
        }

        // POST: KOProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price")] KOProduct product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(200, "Success");
            }
            return new HttpStatusCodeResult(404, "Unable to update.");
        }

        // GET: KOProducts/Delete/5
        public ActionResult Delete()
        {
            return PartialView();
        }

        // POST: KOProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                KOProduct product = db.KOProducts.Find(id);
                db.KOProducts.Remove(product);
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
