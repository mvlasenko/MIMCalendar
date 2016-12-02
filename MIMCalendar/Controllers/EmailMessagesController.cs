using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIMCalendar.Models;

namespace MIMCalendar.Controllers
{
    public class EmailMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmailMessages
        public ActionResult Index()
        {
            var emailMessages = db.EmailMessages.Include(e => e.EmailTemplate).Include(e => e.Group).Include(e => e.Team);
            return View(emailMessages.ToList());
        }

        // GET: EmailMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailMessage emailMessage = db.EmailMessages.Find(id);
            if (emailMessage == null)
            {
                return HttpNotFound();
            }
            return View(emailMessage);
        }

        // GET: EmailMessages/Create
        public ActionResult Create()
        {
            ViewBag.EmailTemplateId = new SelectList(db.EmailTemplates, "Id", "Subject");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: EmailMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailTemplateId,GroupId,TeamId,DateSent")] EmailMessage emailMessage)
        {
            if (ModelState.IsValid)
            {
                db.EmailMessages.Add(emailMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailTemplateId = new SelectList(db.EmailTemplates, "Id", "Subject", emailMessage.EmailTemplateId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", emailMessage.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", emailMessage.TeamId);
            return View(emailMessage);
        }

        // GET: EmailMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailMessage emailMessage = db.EmailMessages.Find(id);
            if (emailMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailTemplateId = new SelectList(db.EmailTemplates, "Id", "Subject", emailMessage.EmailTemplateId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", emailMessage.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", emailMessage.TeamId);
            return View(emailMessage);
        }

        // POST: EmailMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailTemplateId,GroupId,TeamId,DateSent")] EmailMessage emailMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailTemplateId = new SelectList(db.EmailTemplates, "Id", "Subject", emailMessage.EmailTemplateId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", emailMessage.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", emailMessage.TeamId);
            return View(emailMessage);
        }

        // GET: EmailMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailMessage emailMessage = db.EmailMessages.Find(id);
            if (emailMessage == null)
            {
                return HttpNotFound();
            }
            return View(emailMessage);
        }

        // POST: EmailMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailMessage emailMessage = db.EmailMessages.Find(id);
            db.EmailMessages.Remove(emailMessage);
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
