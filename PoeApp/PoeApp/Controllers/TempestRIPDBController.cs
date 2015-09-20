using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoeApp.Models;

namespace PoeApp.Controllers
{
    public class TempestRIPDBController : Controller
    {
        private TempestRIPDBDBContext db = new TempestRIPDBDBContext();

        // GET: /TempestRIPDB/
        public ActionResult Index()
        {
            return View(db.TempestRIPDB.ToList());
        }

        // GET: /TempestRIPDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempestRIPDB tempestripdb = db.TempestRIPDB.Find(id);
            if (tempestripdb == null)
            {
                return HttpNotFound();
            }
            return View(tempestripdb);
        }

        // GET: /TempestRIPDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TempestRIPDB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Character,Rank,Level,Class,Experience,Account")] TempestRIPDB tempestripdb)
        {
            if (ModelState.IsValid)
            {
                db.TempestRIPDB.Add(tempestripdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempestripdb);
        }

        // GET: /TempestRIPDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempestRIPDB tempestripdb = db.TempestRIPDB.Find(id);
            if (tempestripdb == null)
            {
                return HttpNotFound();
            }
            return View(tempestripdb);
        }

        // POST: /TempestRIPDB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Character,Rank,Level,Class,Experience,Account")] TempestRIPDB tempestripdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempestripdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempestripdb);
        }

        // GET: /TempestRIPDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempestRIPDB tempestripdb = db.TempestRIPDB.Find(id);
            if (tempestripdb == null)
            {
                return HttpNotFound();
            }
            return View(tempestripdb);
        }

        // POST: /TempestRIPDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TempestRIPDB tempestripdb = db.TempestRIPDB.Find(id);
            db.TempestRIPDB.Remove(tempestripdb);
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
