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
    public class StoreController : Controller
    {
        private KOModel db = new KOModel();

        // GET: KOStores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStores()
        {
            var stores = (from ru in db.KOStores
                          select ru).ToList()
                           .Select(ru => new KOStore
                           {
                               ID = ru.ID,
                               StoreName = ru.StoreName,
                               StoreAddress = ru.StoreAddress
                           });

            //var stores = db.KOStores.Select(p => new KOStore
            //{
            //    ID = p.ID,
            //    StoreName = p.StoreName,
            //    StoreAddress = p.StoreAddress
            //});
            return Json(stores, JsonRequestBehavior.AllowGet);
        }

        // GET: KOStores/Details/5
        public ActionResult Details()
        {
            return PartialView();
        }

        // GET: KOStores/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: KOStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public long Create([Bind(Include = "ID,StoreName,StoreAddress")] KOStore store)
        {
            long id = 0;
            if (ModelState.IsValid)
            {
                db.KOStores.Add(store);
                db.SaveChanges();
                return store.ID;
            }

            return id;
        }

        // GET: KOStores/Edit/5
        public ActionResult Edit()
        {
            return PartialView();
        }

        // POST: KOStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StoreName,StoreAddress")] KOStore store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(200, "Success");
            }
            return new HttpStatusCodeResult(404, "Unable to update.");
        }

        // GET: KOStores/Delete/5
        public ActionResult Delete()
        {
            return PartialView();
        }

        // POST: KOStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                KOStore store = db.KOStores.Find(id);
                db.KOStores.Remove(store);
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
