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
    public class MensShoesController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: MensShoes
        public ActionResult Index()
        {
            return View(db.MensShoes.ToList());
        }

        // GET: MensShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensSho mensSho = db.MensShoes.Find(id);
            if (mensSho == null)
            {
                return HttpNotFound();
            }
            return View(mensSho);
        }

        // GET: MensShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MensShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensShoesID,Name,Photo,Type,Color,Season,Occasion")] MensSho mensSho)
        {
            if (ModelState.IsValid)
            {
                db.MensShoes.Add(mensSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensSho);
        }

        // GET: MensShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensSho mensSho = db.MensShoes.Find(id);
            if (mensSho == null)
            {
                return HttpNotFound();
            }
            return View(mensSho);
        }

        // POST: MensShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensShoesID,Name,Photo,Type,Color,Season,Occasion")] MensSho mensSho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensSho);
        }

        // GET: MensShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensSho mensSho = db.MensShoes.Find(id);
            if (mensSho == null)
            {
                return HttpNotFound();
            }
            return View(mensSho);
        }

        // POST: MensShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MensSho mensSho = db.MensShoes.Find(id);
            db.MensShoes.Remove(mensSho);
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
