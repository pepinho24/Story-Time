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
    public class StorySentenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StorySentences_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<StorySentence> storysentences = db.StorySentences;
            DataSourceResult result = storysentences.ToDataSourceResult(request, storySentence => new {
                Id = storySentence.Id,
                Content = storySentence.Content,
                Author = storySentence.Author,
                CreatedOn = storySentence.CreatedOn,
                ModifiedOn = storySentence.ModifiedOn,
                IsDeleted = storySentence.IsDeleted,
                DeletedOn = storySentence.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StorySentences_Create([DataSourceRequest]DataSourceRequest request, StorySentence storySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new StorySentence
                {
                    Content = storySentence.Content,
                    Author = storySentence.Author,
                    CreatedOn = storySentence.CreatedOn,
                    ModifiedOn = storySentence.ModifiedOn,
                    IsDeleted = storySentence.IsDeleted,
                    DeletedOn = storySentence.DeletedOn
                };

                db.StorySentences.Add(entity);
                db.SaveChanges();
                storySentence.Id = entity.Id;
            }

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StorySentences_Update([DataSourceRequest]DataSourceRequest request, StorySentence storySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new StorySentence
                {
                    Id = storySentence.Id,
                    Content = storySentence.Content,
                    Author = storySentence.Author,
                    CreatedOn = storySentence.CreatedOn,
                    ModifiedOn = storySentence.ModifiedOn,
                    IsDeleted = storySentence.IsDeleted,
                    DeletedOn = storySentence.DeletedOn
                };

                db.StorySentences.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StorySentences_Destroy([DataSourceRequest]DataSourceRequest request, StorySentence storySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new StorySentence
                {
                    Id = storySentence.Id,
                    Content = storySentence.Content,
                    Author = storySentence.Author,
                    CreatedOn = storySentence.CreatedOn,
                    ModifiedOn = storySentence.ModifiedOn,
                    IsDeleted = storySentence.IsDeleted,
                    DeletedOn = storySentence.DeletedOn
                };

                db.StorySentences.Attach(entity);
                db.StorySentences.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
