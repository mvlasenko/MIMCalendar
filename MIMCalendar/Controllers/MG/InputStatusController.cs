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
    public class InputStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InputStatus
        public ActionResult Index()
        {
            var inputStatus = db.InputStatus.Include(i => i.InputType).Include(i => i.Team).Include(i => i.User);
            return View(inputStatus.ToList());
        }

        // GET: InputStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputStatus inputStatus = db.InputStatus.Find(id);
            if (inputStatus == null)
            {
                return HttpNotFound();
            }
            return View(inputStatus);
        }

        // GET: InputStatus/Create
        public ActionResult Create()
        {
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng");
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: InputStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Period,InputTypeId,UserId,TeamId,Created")] InputStatus inputStatus)
        {
            if (ModelState.IsValid)
            {
                db.InputStatus.Add(inputStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputStatus.InputTypeId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", inputStatus.TeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", inputStatus.UserId);
            return View(inputStatus);
        }

        // GET: InputStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputStatus inputStatus = db.InputStatus.Find(id);
            if (inputStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputStatus.InputTypeId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", inputStatus.TeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", inputStatus.UserId);
            return View(inputStatus);
        }

        // POST: InputStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Period,InputTypeId,UserId,TeamId,Created")] InputStatus inputStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name_eng", inputStatus.InputTypeId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", inputStatus.TeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", inputStatus.UserId);
            return View(inputStatus);
        }

        // GET: InputStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputStatus inputStatus = db.InputStatus.Find(id);
            if (inputStatus == null)
            {
                return HttpNotFound();
            }
            return View(inputStatus);
        }

        // POST: InputStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputStatus inputStatus = db.InputStatus.Find(id);
            db.InputStatus.Remove(inputStatus);
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
