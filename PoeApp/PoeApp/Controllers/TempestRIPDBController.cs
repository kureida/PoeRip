using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoeApp.Models;
using System.Threading.Tasks;

namespace PoeApp.Controllers
{
    public class TempestRIPDBController : Controller
    {

        private PoeRESTService service = new PoeRESTService();
        private TempestRIPDBDBContext db = new TempestRIPDBDBContext();

        
        // GET: /TempestRIPDB/
        public ActionResult Index()
        {
            //return View("index", service.GetLadder());

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

        public ActionResult ClearDB()
        {
            foreach (TempestRIPDB i in db.TempestRIPDB)
            {
                db.TempestRIPDB.Remove(i);

            }
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult PullLadderData()
        {
            int c = 1;
            for (int k = 0; k < 15000; k+=200)
            {
                LadderData ladder = service.GetLadder(k);
                
                foreach (LadderData.Entry i in ladder.entries)
                {
                    if (i.dead)
                    {
                        TempestRIPDB temp = new TempestRIPDB();
                        temp.ID = c;
                        temp.Character = i.character.name;
                        temp.Account = i.account.name;
                        temp.Class = i.character.Class;
                        temp.Experience = i.character.experience;
                        temp.Level = i.character.level;
                        temp.Rank = i.rank;

                        //var duplicate = db.TempestRIPDB.Where(n => n.Character == temp.Character);
                        //if(duplicate.Equals(null))
                        bool dup = false;
                        foreach (TempestRIPDB j in db.TempestRIPDB)
                        {
                            if (j.Character.Equals(temp.Character))
                            {
                                dup = true;
                            }
                        }
                        if (dup == false)
                        {
                            db.TempestRIPDB.Add(temp);
                            c++;
                        }
                        
                    }
                }
                
            }

            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
