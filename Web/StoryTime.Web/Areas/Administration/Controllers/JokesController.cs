using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using StoryTime.Data.Models;
using StoryTime.Data;

namespace StoryTime.Web.Areas.Administration.Controllers
{
    public class JokesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jokes_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Joke> jokes = db.Jokes;
            DataSourceResult result = jokes.ToDataSourceResult(request, joke => new {
                Id = joke.Id,
                Content = joke.Content,
                CreatedOn = joke.CreatedOn,
                ModifiedOn = joke.ModifiedOn,
                IsDeleted = joke.IsDeleted,
                DeletedOn = joke.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Jokes_Create([DataSourceRequest]DataSourceRequest request, Joke joke)
        {
            if (ModelState.IsValid)
            {
                var entity = new Joke
                {
                    Content = joke.Content,
                    CreatedOn = joke.CreatedOn,
                    ModifiedOn = joke.ModifiedOn,
                    IsDeleted = joke.IsDeleted,
                    DeletedOn = joke.DeletedOn
                };

                db.Jokes.Add(entity);
                db.SaveChanges();
                joke.Id = entity.Id;
            }

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Jokes_Update([DataSourceRequest]DataSourceRequest request, Joke joke)
        {
            if (ModelState.IsValid)
            {
                var entity = new Joke
                {
                    Id = joke.Id,
                    Content = joke.Content,
                    CreatedOn = joke.CreatedOn,
                    ModifiedOn = joke.ModifiedOn,
                    IsDeleted = joke.IsDeleted,
                    DeletedOn = joke.DeletedOn
                };

                db.Jokes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Jokes_Destroy([DataSourceRequest]DataSourceRequest request, Joke joke)
        {
            if (ModelState.IsValid)
            {
                var entity = new Joke
                {
                    Id = joke.Id,
                    Content = joke.Content,
                    CreatedOn = joke.CreatedOn,
                    ModifiedOn = joke.ModifiedOn,
                    IsDeleted = joke.IsDeleted,
                    DeletedOn = joke.DeletedOn
                };

                db.Jokes.Attach(entity);
                db.Jokes.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
