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
    public class BUsController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: BUs
        public ActionResult Index()
        {
            var bUs = db.BUs.Include(b => b.FSU);
            return View(bUs.ToList());
        }

        // GET: BUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BU bU = db.BUs.Find(id);
            if (bU == null)
            {
                return HttpNotFound();
            }
            return View(bU);
        }

        // GET: BUs/Create
        public ActionResult Create()
        {
            ViewBag.FsuID = new SelectList(db.FSUs, "Id", "Code");
            return View();
        }

        // POST: BUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FsuID,Code,Name,Lead,Note")] BU bU)
        {
            if (ModelState.IsValid)
            {
                db.BUs.Add(bU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FsuID = new SelectList(db.FSUs, "Id", "Code", bU.FsuID);
            return View(bU);
        }

        // GET: BUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BU bU = db.BUs.Find(id);
            if (bU == null)
            {
                return HttpNotFound();
            }
            ViewBag.FsuID = new SelectList(db.FSUs, "Id", "Code", bU.FsuID);
            return View(bU);
        }

        // POST: BUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FsuID,Code,Name,Lead,Note")] BU bU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FsuID = new SelectList(db.FSUs, "Id", "Code", bU.FsuID);
            return View(bU);
        }

        // GET: BUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BU bU = db.BUs.Find(id);
            if (bU == null)
            {
                return HttpNotFound();
            }
            return View(bU);
        }

        // POST: BUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BU bU = db.BUs.Find(id);
            db.BUs.Remove(bU);
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
