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
using InputType = MIMCalendar.Models.MG.InputType;

namespace MIMCalendar.Controllers.MG
{
    public class InputTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InputTypes
        public ActionResult Index()
        {
            return View(db.InputTypes.ToList());
        }

        // GET: InputTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            return View(inputType);
        }

        // GET: InputTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InputTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus")] InputType inputType)
        {
            if (ModelState.IsValid)
            {
                db.InputTypes.Add(inputType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inputType);
        }

        // GET: InputTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            return View(inputType);
        }

        // POST: InputTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name_eng,Name_ukr,Name_rus")] InputType inputType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inputType);
        }

        // GET: InputTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            return View(inputType);
        }

        // POST: InputTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputType inputType = db.InputTypes.Find(id);
            db.InputTypes.Remove(inputType);
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
