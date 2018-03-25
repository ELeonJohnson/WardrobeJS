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
    public class WomensShoesController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: WomensShoes
        public ActionResult Index()
        {
            return View(db.WomensShoes.ToList());
        }

        // GET: WomensShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensSho womensSho = db.WomensShoes.Find(id);
            if (womensSho == null)
            {
                return HttpNotFound();
            }
            return View(womensSho);
        }

        // GET: WomensShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WomensShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WomensShoesID,Name,Photo,Type,Color,Season,Occasion")] WomensSho womensSho)
        {
            if (ModelState.IsValid)
            {
                db.WomensShoes.Add(womensSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(womensSho);
        }

        // GET: WomensShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensSho womensSho = db.WomensShoes.Find(id);
            if (womensSho == null)
            {
                return HttpNotFound();
            }
            return View(womensSho);
        }

        // POST: WomensShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WomensShoesID,Name,Photo,Type,Color,Season,Occasion")] WomensSho womensSho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(womensSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(womensSho);
        }

        // GET: WomensShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensSho womensSho = db.WomensShoes.Find(id);
            if (womensSho == null)
            {
                return HttpNotFound();
            }
            return View(womensSho);
        }

        // POST: WomensShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WomensSho womensSho = db.WomensShoes.Find(id);
            db.WomensShoes.Remove(womensSho);
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
