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
    public class MensTopsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: MensTops
        public ActionResult Index()
        {
            return View(db.MensTops.ToList());
        }

        // GET: MensTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensTop mensTop = db.MensTops.Find(id);
            if (mensTop == null)
            {
                return HttpNotFound();
            }
            return View(mensTop);
        }

        // GET: MensTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensTopsID,Name,Photo,Type,Color,Season,Occasion")] MensTop mensTop)
        {
            if (ModelState.IsValid)
            {
                db.MensTops.Add(mensTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensTop);
        }

        // GET: MensTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensTop mensTop = db.MensTops.Find(id);
            if (mensTop == null)
            {
                return HttpNotFound();
            }
            return View(mensTop);
        }

        // POST: MensTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensTopsID,Name,Photo,Type,Color,Season,Occasion")] MensTop mensTop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensTop);
        }

        // GET: MensTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensTop mensTop = db.MensTops.Find(id);
            if (mensTop == null)
            {
                return HttpNotFound();
            }
            return View(mensTop);
        }

        // POST: MensTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MensTop mensTop = db.MensTops.Find(id);
            db.MensTops.Remove(mensTop);
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
