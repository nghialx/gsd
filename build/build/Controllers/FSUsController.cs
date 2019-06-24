using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using build.Models;

namespace build.Controllers
{
    public class FSUsController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: FSUs
        public ActionResult Index()
        {
            return View(db.FSUs.ToList());
        }

        // GET: FSUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSU fSU = db.FSUs.Find(id);
            if (fSU == null)
            {
                return HttpNotFound();
            }
            return View(fSU);
        }

        // GET: FSUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FSUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Lead")] FSU fSU)
        {
            if (ModelState.IsValid)
            {
                db.FSUs.Add(fSU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fSU);
        }

        // GET: FSUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSU fSU = db.FSUs.Find(id);
            if (fSU == null)
            {
                return HttpNotFound();
            }
            return View(fSU);
        }

        // POST: FSUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Lead")] FSU fSU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fSU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fSU);
        }

        // GET: FSUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSU fSU = db.FSUs.Find(id);
            if (fSU == null)
            {
                return HttpNotFound();
            }
            return View(fSU);
        }

        // POST: FSUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FSU fSU = db.FSUs.Find(id);
            db.FSUs.Remove(fSU);
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
