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
    public class MensAccessoriesController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: MensAccessories
        public ActionResult Index()
        {
            return View(db.MensAccessories.ToList());
        }

        // GET: MensAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensAccessory mensAccessory = db.MensAccessories.Find(id);
            if (mensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(mensAccessory);
        }

        // GET: MensAccessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensAccessoriesID,Name,Photo,Type,Color,Season,Occasion")] MensAccessory mensAccessory)
        {
            if (ModelState.IsValid)
            {
                db.MensAccessories.Add(mensAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensAccessory);
        }

        // GET: MensAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensAccessory mensAccessory = db.MensAccessories.Find(id);
            if (mensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(mensAccessory);
        }

        // POST: MensAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensAccessoriesID,Name,Photo,Type,Color,Season,Occasion")] MensAccessory mensAccessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensAccessory);
        }

        // GET: MensAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensAccessory mensAccessory = db.MensAccessories.Find(id);
            if (mensAccessory == null)
            {
                return HttpNotFound();
            }
            return View(mensAccessory);
        }

        // POST: MensAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MensAccessory mensAccessory = db.MensAccessories.Find(id);
            db.MensAccessories.Remove(mensAccessory);
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
