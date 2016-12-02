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
    public class InputSubTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InputSubTypes
        public ActionResult Index()
        {
            return View(db.InputSubTypes.ToList());
        }

        // GET: InputSubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputSubType inputSubType = db.InputSubTypes.Find(id);
            if (inputSubType == null)
            {
                return HttpNotFound();
            }
            return View(inputSubType);
        }

        // GET: InputSubTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InputSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus")] InputSubType inputSubType)
        {
            if (ModelState.IsValid)
            {
                db.InputSubTypes.Add(inputSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inputSubType);
        }

        // GET: InputSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputSubType inputSubType = db.InputSubTypes.Find(id);
            if (inputSubType == null)
            {
                return HttpNotFound();
            }
            return View(inputSubType);
        }

        // POST: InputSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus")] InputSubType inputSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inputSubType);
        }

        // GET: InputSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputSubType inputSubType = db.InputSubTypes.Find(id);
            if (inputSubType == null)
            {
                return HttpNotFound();
            }
            return View(inputSubType);
        }

        // POST: InputSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputSubType inputSubType = db.InputSubTypes.Find(id);
            db.InputSubTypes.Remove(inputSubType);
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
