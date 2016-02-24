namespace StoryTime.Web.Areas.Administration.Controllers
{
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
    using StoryTime.Data;
    using StoryTime.Data.Models;

    public class StoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stories_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Story> stories = db.Stories;
            DataSourceResult result = stories.ToDataSourceResult(request, story => new {
                Id = story.Id,
                Title = story.Title,
                Creator = story.Creator,
                WriterInTurn = story.WriterInTurn,
                IsStoryFinished = story.IsStoryFinished,
                CreatedOn = story.CreatedOn,
                ModifiedOn = story.ModifiedOn,
                IsDeleted = story.IsDeleted,
                DeletedOn = story.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Create([DataSourceRequest]DataSourceRequest request, Story story)
        {
            if (ModelState.IsValid)
            {
                var entity = new Story
                {
                    Title = story.Title,
                    Creator = story.Creator,
                    WriterInTurn = story.WriterInTurn,
                    IsStoryFinished = story.IsStoryFinished,
                    CreatedOn = story.CreatedOn,
                    ModifiedOn = story.ModifiedOn,
                    IsDeleted = story.IsDeleted,
                    DeletedOn = story.DeletedOn
                };

                db.Stories.Add(entity);
                db.SaveChanges();
                story.Id = entity.Id;
            }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Update([DataSourceRequest]DataSourceRequest request, Story story)
        {
            if (ModelState.IsValid)
            {
                var entity = new Story
                {
                    Id = story.Id,
                    Title = story.Title,
                    Creator = story.Creator,
                    WriterInTurn = story.WriterInTurn,
                    IsStoryFinished = story.IsStoryFinished,
                    CreatedOn = story.CreatedOn,
                    ModifiedOn = story.ModifiedOn,
                    IsDeleted = story.IsDeleted,
                    DeletedOn = story.DeletedOn
                };

                db.Stories.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Destroy([DataSourceRequest]DataSourceRequest request, Story story)
        {
            if (ModelState.IsValid)
            {
                var entity = new Story
                {
                    Id = story.Id,
                    Title = story.Title,
                    Creator = story.Creator,
                    WriterInTurn = story.WriterInTurn,
                    IsStoryFinished = story.IsStoryFinished,
                    CreatedOn = story.CreatedOn,
                    ModifiedOn = story.ModifiedOn,
                    IsDeleted = story.IsDeleted,
                    DeletedOn = story.DeletedOn
                };

                db.Stories.Attach(entity);
                db.Stories.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
