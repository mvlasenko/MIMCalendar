using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIMCalendar.Models;
using MIMCalendar.Models.MG;

namespace MIMCalendar.Controllers.MG
{
    public class InputDefinitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InputDefinitions
        public ActionResult Index()
        {
            var inputDefinitions = db.InputDefinitions.Include(i => i.InputSubType).Include(i => i.InputType).Include(i => i.Market).Include(i => i.Product).Include(i => i.Unit);
            return View(inputDefinitions.ToList());
        }

        // GET: InputDefinitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDefinition inputDefinition = db.InputDefinitions.Find(id);
            if (inputDefinition == null)
            {
                return HttpNotFound();
            }
            return View(inputDefinition);
        }

        // GET: InputDefinitions/Create
        public ActionResult Create()
        {
            ViewBag.InputSubTypeId = new SelectList(db.InputSubTypes, "Id", "Name_eng");
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng");
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name_eng");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name_eng");
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name_eng");
            return View();
        }

        // POST: InputDefinitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus,InputTypeId,InputSubTypeId,ProductId,MarketId,UnitId,Required,Autofill,Group,NonMatch,Percent100,Seq")] InputDefinition inputDefinition)
        {
            if (ModelState.IsValid)
            {
                db.InputDefinitions.Add(inputDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InputSubTypeId = new SelectList(db.InputSubTypes, "Id", "Name_eng", inputDefinition.InputSubTypeId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputDefinition.InputTypeId);
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name_eng", inputDefinition.MarketId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name_eng", inputDefinition.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name_eng", inputDefinition.UnitId);
            return View(inputDefinition);
        }

        // GET: InputDefinitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDefinition inputDefinition = db.InputDefinitions.Find(id);
            if (inputDefinition == null)
            {
                return HttpNotFound();
            }
            ViewBag.InputSubTypeId = new SelectList(db.InputSubTypes, "Id", "Name_eng", inputDefinition.InputSubTypeId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputDefinition.InputTypeId);
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name_eng", inputDefinition.MarketId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name_eng", inputDefinition.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name_eng", inputDefinition.UnitId);
            return View(inputDefinition);
        }

        // POST: InputDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus,InputTypeId,InputSubTypeId,ProductId,MarketId,UnitId,Required,Autofill,Group,NonMatch,Percent100,Seq")] InputDefinition inputDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InputSubTypeId = new SelectList(db.InputSubTypes, "Id", "Name_eng", inputDefinition.InputSubTypeId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputDefinition.InputTypeId);
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name_eng", inputDefinition.MarketId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name_eng", inputDefinition.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Name_eng", inputDefinition.UnitId);
            return View(inputDefinition);
        }

        // GET: InputDefinitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDefinition inputDefinition = db.InputDefinitions.Find(id);
            if (inputDefinition == null)
            {
                return HttpNotFound();
            }
            return View(inputDefinition);
        }

        // POST: InputDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputDefinition inputDefinition = db.InputDefinitions.Find(id);
            db.InputDefinitions.Remove(inputDefinition);
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
