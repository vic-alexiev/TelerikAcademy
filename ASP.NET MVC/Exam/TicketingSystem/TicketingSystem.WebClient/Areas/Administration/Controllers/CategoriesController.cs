using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TicketingSystem.Data;
using TicketingSystem.Models;
using TicketingSystem.WebClient.Controllers;
using TicketingSystem.WebClient.Models;

namespace TicketingSystem.WebClient.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : BaseController
    {
        // GET: /Administration/Categories/
        public ActionResult Index()
        {
            return View(this.Data.GetRepository<Category>().All().ToList());
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<CategoryViewModel> categories = GetCategories();

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // GET: /Administration/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administration/Categories/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Name = category.Name
                };

                this.Data.GetRepository<Category>().Add(newCategory);
                this.Data.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: /Administration/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.Data.GetRepository<Category>().GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryToEdit = CategoryViewModel.ConvertFrom(category);

            return View(categoryToEdit);
        }

        // POST: /Administration/Categories/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var currentCategory = this.Data.GetRepository<Category>().GetById(category.Id);
                currentCategory.Name = category.Name;

                this.Data.GetRepository<Category>().Update(currentCategory);
                this.Data.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Administration/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.Data.GetRepository<Category>().GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tickets = this.Data.GetRepository<Ticket>()
                .All()
                .Where(t => t.Category.Id == id);

            foreach (var ticket in tickets)
            {
                var comments = this.Data.GetRepository<Comment>()
                    .All()
                    .Where(c => c.Ticket.Id == ticket.Id);
                foreach (var comment in comments)
                {
                    this.Data.GetRepository<Comment>().Delete(comment);
                }

                this.Data.GetRepository<Ticket>().Delete(ticket);
            }

            Category category = this.Data.GetRepository<Category>().GetById(id);
            this.Data.GetRepository<Category>().Delete(category);
            this.Data.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private IQueryable<CategoryViewModel> GetCategories()
        {
            IQueryable<CategoryViewModel> categories =
                this.Data.GetRepository<Category>().All()
                .Select(CategoryViewModel.FromCategory);
            return categories;
        }
    }
}
