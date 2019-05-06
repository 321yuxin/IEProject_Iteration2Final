using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IEProject_AfterIteration1.Models;

namespace IEProject_AfterIteration1.Controllers
{
    public class SuperMarketsController : Controller
    {
        private HousingNorm db = new HousingNorm();

        // GET: SuperMarkets
        public ActionResult Index()
        {
            return View(db.SuperMarkets.ToList());
        }

        // GET: SuperMarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMarket superMarket = db.SuperMarkets.Find(id);
            if (superMarket == null)
            {
                return HttpNotFound();
            }
            return View(superMarket);
        }

        // GET: SuperMarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperMarkets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Suburb,Name,Latitude,Longitude")] SuperMarket superMarket)
        {
            if (ModelState.IsValid)
            {
                db.SuperMarkets.Add(superMarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(superMarket);
        }

        // GET: SuperMarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMarket superMarket = db.SuperMarkets.Find(id);
            if (superMarket == null)
            {
                return HttpNotFound();
            }
            return View(superMarket);
        }

        // POST: SuperMarkets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Suburb,Name,Latitude,Longitude")] SuperMarket superMarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superMarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superMarket);
        }

        // GET: SuperMarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMarket superMarket = db.SuperMarkets.Find(id);
            if (superMarket == null)
            {
                return HttpNotFound();
            }
            return View(superMarket);
        }

        // POST: SuperMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuperMarket superMarket = db.SuperMarkets.Find(id);
            db.SuperMarkets.Remove(superMarket);
            db.SaveChanges();
            return RedirectToAction("Index");
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
