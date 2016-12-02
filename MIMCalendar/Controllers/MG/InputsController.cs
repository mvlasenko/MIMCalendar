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
    public class InputsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inputs
        public ActionResult Index()
        {
            var inputs = db.Inputs.Include(i => i.InputDefinition).Include(i => i.Period).Include(i => i.Team);
            return View(inputs.ToList());
        }

        // GET: Inputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Inputs.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            return View(input);
        }

        // GET: Inputs/Create
        public ActionResult Create()
        {
            ViewBag.InputDefinitionId = new SelectList(db.InputDefinitions, "Id", "Name_eng");
            ViewBag.PeriodId = new SelectList(db.Periods, "Id", "Id");
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Inputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PeriodId,InputDefinitionId,TeamId,Value")] Input input)
        {
            if (ModelState.IsValid)
            {
                db.Inputs.Add(input);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InputDefinitionId = new SelectList(db.InputDefinitions, "Id", "Name_eng", input.InputDefinitionId);
            ViewBag.PeriodId = new SelectList(db.Periods, "Id", "Id", input.PeriodId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", input.TeamId);
            return View(input);
        }

        // GET: Inputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Inputs.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            ViewBag.InputDefinitionId = new SelectList(db.InputDefinitions, "Id", "Name_eng", input.InputDefinitionId);
            ViewBag.PeriodId = new SelectList(db.Periods, "Id", "Id", input.PeriodId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", input.TeamId);
            return View(input);
        }

        // POST: Inputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PeriodId,InputDefinitionId,TeamId,Value")] Input input)
        {
            if (ModelState.IsValid)
            {
                db.Entry(input).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InputDefinitionId = new SelectList(db.InputDefinitions, "Id", "Name_eng", input.InputDefinitionId);
            ViewBag.PeriodId = new SelectList(db.Periods, "Id", "Id", input.PeriodId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", input.TeamId);
            return View(input);
        }

        // GET: Inputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Inputs.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            return View(input);
        }

        // POST: Inputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Input input = db.Inputs.Find(id);
            db.Inputs.Remove(input);
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
