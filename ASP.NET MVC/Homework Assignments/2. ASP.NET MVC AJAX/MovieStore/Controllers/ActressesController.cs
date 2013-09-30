using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieStore;
using MovieStore.Data;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class ActressesController : Controller
    {
        private MovieStoreContext db = new MovieStoreContext();

        // GET: /Actresses/
        public ActionResult Index()
        {
            return View(db.Actresses.ToList());
        }

        // GET: /Actresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actresses.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", actress);
        }

        // GET: /Actresses/Create
        public ActionResult Create()
        {
            return PartialView("_Create", new Actress());
        }

        // POST: /Actresses/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actress actress)
        {
            if (ModelState.IsValid)
            {
                db.Actresses.Add(actress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actress);
        }

        // GET: /Actresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actresses.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", actress);
        }

        // POST: /Actresses/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actress actress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actress);
        }

        // GET: /Actresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actresses.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", actress);
        }

        // POST: /Actresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (var movie in db.Movies.Where(m => m.ActressId == id))
            {
                movie.ActressId = null;
            }

            Actress actress = db.Actresses.Find(id);
            db.Actresses.Remove(actress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
