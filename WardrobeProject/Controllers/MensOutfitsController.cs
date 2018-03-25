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
    public class MensOutfitsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: MensOutfits
        public ActionResult Index()
        {
            var mensOutfits = db.MensOutfits.Include(m => m.MensAccessory).Include(m => m.MensBottom).Include(m => m.MensSho).Include(m => m.MensTop);
            return View(mensOutfits.ToList());
        }

        // GET: MensOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensOutfit mensOutfit = db.MensOutfits.Find(id);
            if (mensOutfit == null)
            {
                return HttpNotFound();
            }
            return View(mensOutfit);
        }

        // GET: MensOutfits/Create
        public ActionResult Create()
        {
            ViewBag.MensAccessoriesID = new SelectList(db.MensAccessories, "MensAccessoriesID", "Name");
            ViewBag.MensBottomsID = new SelectList(db.MensBottoms, "MensBottomsID", "Name");
            ViewBag.MensShoesID = new SelectList(db.MensShoes, "MensShoesID", "Name");
            ViewBag.MensTopsID = new SelectList(db.MensTops, "MensTopsID", "Name");
            return View();
        }

        // POST: MensOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensOutfitsID,MensAccessoriesID,MensBottomsID,MensShoesID,MensTopsID")] MensOutfit mensOutfit)
        {
            if (ModelState.IsValid)
            {
                db.MensOutfits.Add(mensOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MensAccessoriesID = new SelectList(db.MensAccessories, "MensAccessoriesID", "Name", mensOutfit.MensAccessoriesID);
            ViewBag.MensBottomsID = new SelectList(db.MensBottoms, "MensBottomsID", "Name", mensOutfit.MensBottomsID);
            ViewBag.MensShoesID = new SelectList(db.MensShoes, "MensShoesID", "Name", mensOutfit.MensShoesID);
            ViewBag.MensTopsID = new SelectList(db.MensTops, "MensTopsID", "Name", mensOutfit.MensTopsID);
            return View(mensOutfit);
        }

        // GET: MensOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensOutfit mensOutfit = db.MensOutfits.Find(id);
            if (mensOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.MensAccessoriesID = new SelectList(db.MensAccessories, "MensAccessoriesID", "Name", mensOutfit.MensAccessoriesID);
            ViewBag.MensBottomsID = new SelectList(db.MensBottoms, "MensBottomsID", "Name", mensOutfit.MensBottomsID);
            ViewBag.MensShoesID = new SelectList(db.MensShoes, "MensShoesID", "Name", mensOutfit.MensShoesID);
            ViewBag.MensTopsID = new SelectList(db.MensTops, "MensTopsID", "Name", mensOutfit.MensTopsID);
            return View(mensOutfit);
        }

        // POST: MensOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensOutfitsID,MensAccessoriesID,MensBottomsID,MensShoesID,MensTopsID")] MensOutfit mensOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MensAccessoriesID = new SelectList(db.MensAccessories, "MensAccessoriesID", "Name", mensOutfit.MensAccessoriesID);
            ViewBag.MensBottomsID = new SelectList(db.MensBottoms, "MensBottomsID", "Name", mensOutfit.MensBottomsID);
            ViewBag.MensShoesID = new SelectList(db.MensShoes, "MensShoesID", "Name", mensOutfit.MensShoesID);
            ViewBag.MensTopsID = new SelectList(db.MensTops, "MensTopsID", "Name", mensOutfit.MensTopsID);
            return View(mensOutfit);
        }

        // GET: MensOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MensOutfit mensOutfit = db.MensOutfits.Find(id);
            if (mensOutfit == null)
            {
                return HttpNotFound();
            }
            return View(mensOutfit);
        }

        // POST: MensOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MensOutfit mensOutfit = db.MensOutfits.Find(id);
            db.MensOutfits.Remove(mensOutfit);
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
