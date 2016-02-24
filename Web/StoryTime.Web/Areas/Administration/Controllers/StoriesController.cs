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

    using Data.Common;

    public class StoriesController : Controller
    {
        private readonly IDbRepository<Story> stories;

        public StoriesController(IDbRepository<Story> stories)
        {
            this.stories = stories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.stories.All().ToDataSourceResult(request, story => new
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
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Create([DataSourceRequest]DataSourceRequest request, Story story)
        {
            // dates in the story might make the modelstate invalid
            //if (ModelState.IsValid)
            //{
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

                this.stories.Add(entity);
                this.stories.Save();
                story.Id = entity.Id;
           // }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Update([DataSourceRequest]DataSourceRequest request, Story story)
        {
           // if (ModelState.IsValid)
           // {
                var entity = this.stories.GetById(story.Id);
                entity.IsDeleted = story.IsDeleted;
                entity.IsStoryFinished = story.IsStoryFinished;
                entity.Title = story.Title;
                entity.WriterInTurn = story.WriterInTurn;
                this.stories.Save();
           // }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stories_Destroy([DataSourceRequest]DataSourceRequest request, Story story)
        {
            // dates in the story might make the modelstate invalid
            //if (ModelState.IsValid)
            //{
                this.stories.Delete(this.stories.GetById(story.Id));
           // }

            return Json(new[] { story }.ToDataSourceResult(request, ModelState));
        }
    }
}
