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
    public class WomensTopsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: WomensTops
        public ActionResult Index()
        {
            return View(db.WomensTops.ToList());
        }

        // GET: WomensTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensTop womensTop = db.WomensTops.Find(id);
            if (womensTop == null)
            {
                return HttpNotFound();
            }
            return View(womensTop);
        }

        // GET: WomensTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WomensTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WomensTopsID,Name,Photo,Type,Color,Season,Occasion")] WomensTop womensTop)
        {
            if (ModelState.IsValid)
            {
                db.WomensTops.Add(womensTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(womensTop);
        }

        // GET: WomensTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensTop womensTop = db.WomensTops.Find(id);
            if (womensTop == null)
            {
                return HttpNotFound();
            }
            return View(womensTop);
        }

        // POST: WomensTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WomensTopsID,Name,Photo,Type,Color,Season,Occasion")] WomensTop womensTop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(womensTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(womensTop);
        }

        // GET: WomensTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensTop womensTop = db.WomensTops.Find(id);
            if (womensTop == null)
            {
                return HttpNotFound();
            }
            return View(womensTop);
        }

        // POST: WomensTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WomensTop womensTop = db.WomensTops.Find(id);
            db.WomensTops.Remove(womensTop);
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
