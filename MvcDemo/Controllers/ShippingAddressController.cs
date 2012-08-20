using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class ShippingAddressController : Controller
    {
        private MvcDemoContext db = new MvcDemoContext();

        public ActionResult JsonQuickSearch(string q)
        {
            var model = db.ShippingAddresses.Where(x => x.LastName.StartsWith(q)).Take(10)
                .Select(r => new { Index = r.Index, FirstName = r.FirstName, LastName = r.LastName});

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickSearch(string term)
        {
            var model = db.ShippingAddresses.Where(x => x.FirstName.StartsWith(term)).Take(10)
                .Select(r => new {label = r.FirstName});

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Last()
        {
            var model = db.ShippingAddresses.FindLast(1).Single();
            return PartialView("_ShippingAddress", model);
        }

        public PartialViewResult Search(string q)
        {
            var model = db.ShippingAddresses.Where(x => x.FirstName.StartsWith(q) || x.LastName.StartsWith(q)).Take(10);
            return PartialView("_SearchResults", model);
        }
        //
        // GET: /ShippingAddress/

        public ActionResult Index()
        {
            return View(db.ShippingAddresses.ToList());
        }

        //
        // GET: /ShippingAddress/Details/5

        public ActionResult Details(int id = 0)
        {
            ShippingAddress shippingaddress = db.ShippingAddresses.Find(id);
            if (shippingaddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingaddress);
        }

        //
        // GET: /ShippingAddress/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShippingAddress/Create

        [HttpPost]
        public ActionResult Create(ShippingAddress shippingaddress)
        {
            if (ModelState.IsValid)
            {
                db.ShippingAddresses.Add(shippingaddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingaddress);
        }

        //
        // GET: /ShippingAddress/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShippingAddress shippingaddress = db.ShippingAddresses.Find(id);
            if (shippingaddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingaddress);
        }

        //
        // POST: /ShippingAddress/Edit/5

        [HttpPost]
        public ActionResult Edit(ShippingAddress shippingaddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingaddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingaddress);
        }

        //
        // GET: /ShippingAddress/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShippingAddress shippingaddress = db.ShippingAddresses.Find(id);
            if (shippingaddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingaddress);
        }

        //
        // POST: /ShippingAddress/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingAddress shippingaddress = db.ShippingAddresses.Find(id);
            db.ShippingAddresses.Remove(shippingaddress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}