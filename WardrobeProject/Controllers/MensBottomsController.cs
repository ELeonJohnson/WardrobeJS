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
    public class MensBottomsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: MensBottoms
        public ActionResult Index()
        {
            return View(db.MensBottoms.ToList());
        }

        // GET: MensBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensBottom mensBottom = db.MensBottoms.Find(id);
            if (mensBottom == null)
            {
                return HttpNotFound();
            }
            return View(mensBottom);
        }

        // GET: MensBottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensBottomsID,Name,Photo,Type,Color,Season,Occasion")] MensBottom mensBottom)
        {
            if (ModelState.IsValid)
            {
                db.MensBottoms.Add(mensBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensBottom);
        }

        // GET: MensBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensBottom mensBottom = db.MensBottoms.Find(id);
            if (mensBottom == null)
            {
                return HttpNotFound();
            }
            return View(mensBottom);
        }

        // POST: MensBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensBottomsID,Name,Photo,Type,Color,Season,Occasion")] MensBottom mensBottom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensBottom);
        }

        // GET: MensBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensBottom mensBottom = db.MensBottoms.Find(id);
            if (mensBottom == null)
            {
                return HttpNotFound();
            }
            return View(mensBottom);
        }

        // POST: MensBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MensBottom mensBottom = db.MensBottoms.Find(id);
            db.MensBottoms.Remove(mensBottom);
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
