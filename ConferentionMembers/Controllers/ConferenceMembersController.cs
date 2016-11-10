using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConferentionMembers.Models;
using PagedList;

namespace ConferentionMembers.Controllers
{
    public class ConferenceMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConferenceMembers
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "";
            ViewBag.YearOfBirthSortParm = sortOrder == "YearOfBirth" ? "YearOfBirthDesc" : "YearOfBirth";

            var conferenceMembers = from c in db.ConferenceMembers
                                    select c;
            switch (sortOrder)
            {
                case "YearOfBirth":
                    conferenceMembers = conferenceMembers.OrderBy(s => s.YearOfBirth);
                    break;
                case "YearOfBirthDesc":
                    conferenceMembers = conferenceMembers.OrderByDescending(s => s.YearOfBirth);
                    break;
                case "LastNameDesc":
                    conferenceMembers = conferenceMembers.OrderByDescending(s => s.LastName);
                    break;
                default:  // Last Name ASC 
                    conferenceMembers = conferenceMembers.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(conferenceMembers.ToPagedList(pageNumber, pageSize));
        }

        // GET: ConferenceMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceMember conferenceMember = db.ConferenceMembers.Find(id);
            if (conferenceMember == null)
            {
                return HttpNotFound();
            }
            return View(conferenceMember);
        }

        // GET: ConferenceMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferenceMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Address,City,YearOfBirth,Education")] ConferenceMember conferenceMember)
        {
            if (ModelState.IsValid)
            {
                db.ConferenceMembers.Add(conferenceMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conferenceMember);
        }

        // GET: ConferenceMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceMember conferenceMember = db.ConferenceMembers.Find(id);
            if (conferenceMember == null)
            {
                return HttpNotFound();
            }
            return View(conferenceMember);
        }

        // POST: ConferenceMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Address,City,YearOfBirth,Education")] ConferenceMember conferenceMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conferenceMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conferenceMember);
        }

        // GET: ConferenceMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceMember conferenceMember = db.ConferenceMembers.Find(id);
            if (conferenceMember == null)
            {
                return HttpNotFound();
            }
            return View(conferenceMember);
        }

        // POST: ConferenceMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConferenceMember conferenceMember = db.ConferenceMembers.Find(id);
            db.ConferenceMembers.Remove(conferenceMember);
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
