using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeProject.Models;

namespace WardrobeProject.Controllers
{
    public class WomensBottomsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: WomensBottoms
        public ActionResult Index()
        {
            return View(db.WomensBottoms.ToList());
        }

        // GET: WomensBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensBottom womensBottom = db.WomensBottoms.Find(id);
            if (womensBottom == null)
            {
                return HttpNotFound();
            }
            return View(womensBottom);
        }

        // GET: WomensBottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WomensBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WomensBottomsID,Name,Photo,Type,Color,Season,Occasion")] WomensBottom womensBottom)
        {
            if (ModelState.IsValid)
            {
                db.WomensBottoms.Add(womensBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(womensBottom);
        }

        // GET: WomensBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensBottom womensBottom = db.WomensBottoms.Find(id);
            if (womensBottom == null)
            {
                return HttpNotFound();
            }
            return View(womensBottom);
        }

        // POST: WomensBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WomensBottomsID,Name,Photo,Type,Color,Season,Occasion")] WomensBottom womensBottom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(womensBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(womensBottom);
        }

        // GET: WomensBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensBottom womensBottom = db.WomensBottoms.Find(id);
            if (womensBottom == null)
            {
                return HttpNotFound();
            }
            return View(womensBottom);
        }

        // POST: WomensBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WomensBottom womensBottom = db.WomensBottoms.Find(id);
            db.WomensBottoms.Remove(womensBottom);
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
