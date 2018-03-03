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
    public class CustomerController : Controller
    {
        private KOModel db = new KOModel();

        // GET: KOCustomers
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomers()
        {
            var customers = (from ru in db.KOCustomers
                             select ru).ToList()
                           .Select(ru => new KOCustomer
                           {
                               ID = ru.ID,
                               CustomerName = ru.CustomerName,
                               CustomerAddress = ru.CustomerAddress
                           });

            //var customers = db.KOCustomers.Select(p => new KOCustomer
            //{
            //    ID = p.ID,
            //    CustomerName = p.CustomerName,
            //    CustomerAddress = p.CustomerAddress
            //});
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        // GET: KOCustomers/Details/5
        public ActionResult Details()
        {
            return PartialView();
        }

        // GET: KOCustomers/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: KOCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public long Create([Bind(Include = "ID,CustomerName,CustomerAddress")] KOCustomer customer)
        {
            long id = 0;
            if (ModelState.IsValid)
            {
                db.KOCustomers.Add(customer);
                db.SaveChanges();
                return customer.ID;
            }

            return id;
        }

        // GET: KOCustomers/Edit/5
        public ActionResult Edit()
        {
            return PartialView();
        }

        // POST: KOCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,CustomerAddress")] KOCustomer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(200, "Success");
            }
            return new HttpStatusCodeResult(404, "Unable to update.");
        }

        // GET: KOCustomers/Delete/5
        public ActionResult Delete()
        {
            return PartialView();
        }

        // POST: KOCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                KOCustomer customer = db.KOCustomers.Find(id);
                db.KOCustomers.Remove(customer);
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
