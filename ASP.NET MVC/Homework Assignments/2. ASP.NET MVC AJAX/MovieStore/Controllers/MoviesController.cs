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
    public class MoviesController : Controller
    {
        private MovieStoreContext db = new MovieStoreContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Actor).Include(m => m.Actress).Include(m => m.Director).Include(m => m.Studio);
            return View(movies.ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name");
            ViewBag.ActressId = new SelectList(db.Actresses, "Id", "Name");
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name");
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name");
            return PartialView("_Create", new Movie());
        }

        // POST: /Movies/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", movie.ActorId);
            ViewBag.ActressId = new SelectList(db.Actresses, "Id", "Name", movie.ActressId);
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", movie.DirectorId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", movie.ActorId);
            ViewBag.ActressId = new SelectList(db.Actresses, "Id", "Name", movie.ActressId);
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", movie.DirectorId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return PartialView("_Edit", movie);
        }

        // POST: /Movies/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", movie.ActorId);
            ViewBag.ActressId = new SelectList(db.Actresses, "Id", "Name", movie.ActressId);
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", movie.DirectorId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
