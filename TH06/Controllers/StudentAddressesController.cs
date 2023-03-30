using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TH06.DAL;
using TH06.Models;

namespace TH06.Controllers
{
    public class StudentAddressesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: StudentAddresses
        public ActionResult Index()
        {
            var studentAddress = db.StudentAddress.Include(s => s.Student);
            return View(studentAddress.ToList());
        }

        // GET: StudentAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            return View(studentAddress);
        }

        // GET: StudentAddresses/Create
        public ActionResult Create()
        {
            ViewBag.StudentAddressId = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: StudentAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAddressId,Address1,Address2,City,Zipcode,State,Country")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                db.StudentAddress.Add(studentAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentAddressId = new SelectList(db.Students, "Id", "Name", studentAddress.StudentAddressId);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentAddressId = new SelectList(db.Students, "Id", "Name", studentAddress.StudentAddressId);
            return View(studentAddress);
        }

        // POST: StudentAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentAddressId,Address1,Address2,City,Zipcode,State,Country")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentAddressId = new SelectList(db.Students, "Id", "Name", studentAddress.StudentAddressId);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            return View(studentAddress);
        }

        // POST: StudentAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            db.StudentAddress.Remove(studentAddress);
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
