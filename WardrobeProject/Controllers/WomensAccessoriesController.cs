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
    public class WomensAccessoriesController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: WomensAccessories
        public ActionResult Index()
        {
            return View(db.WomensAccessories.ToList());
        }

        // GET: WomensAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensAccessory womensAccessory = db.WomensAccessories.Find(id);
            if (womensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(womensAccessory);
        }

        // GET: WomensAccessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WomensAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WomensAccessoriesID,Name,Photo,Type,Color,Season,Occasion")] WomensAccessory womensAccessory)
        {
            if (ModelState.IsValid)
            {
                db.WomensAccessories.Add(womensAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(womensAccessory);
        }

        // GET: WomensAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensAccessory womensAccessory = db.WomensAccessories.Find(id);
            if (womensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(womensAccessory);
        }

        // POST: WomensAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WomensAccessoriesID,Name,Photo,Type,Color,Season,Occasion")] WomensAccessory womensAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(womensAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(womensAccessory);
        }

        // GET: WomensAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensAccessory womensAccessory = db.WomensAccessories.Find(id);
            if (womensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(womensAccessory);
        }

        // POST: WomensAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WomensAccessory womensAccessory = db.WomensAccessories.Find(id);
            db.WomensAccessories.Remove(womensAccessory);
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
