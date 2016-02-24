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

    public class TemplateStoriesController : Controller
    {
        private readonly IDbRepository<TemplateStory> stories;

        public TemplateStoriesController(IDbRepository<TemplateStory> stories)
        {
            this.stories = stories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TemplateStories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.stories.All().ToDataSourceResult(request, templateStory => new
            {
                Id = templateStory.Id,
                Title = templateStory.Title,
                Narrator = templateStory.Narrator,
                CharacterInTurn = templateStory.CharacterInTurn,
                IsStoryFinished = templateStory.IsStoryFinished,
                CreatedOn = templateStory.CreatedOn,
                ModifiedOn = templateStory.ModifiedOn,
                IsDeleted = templateStory.IsDeleted,
                DeletedOn = templateStory.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStories_Create([DataSourceRequest]DataSourceRequest request, TemplateStory templateStory)
        {
            //if (ModelState.IsValid)
            //{
            var entity = new TemplateStory
            {
                Title = templateStory.Title,
                Narrator = templateStory.Narrator,
                CharacterInTurn = templateStory.CharacterInTurn,
                IsStoryFinished = templateStory.IsStoryFinished,
                CreatedOn = templateStory.CreatedOn,
                ModifiedOn = templateStory.ModifiedOn,
                IsDeleted = templateStory.IsDeleted,
                DeletedOn = templateStory.DeletedOn
            };

            this.stories.Add(entity);
            this.stories.Save();
            templateStory.Id = entity.Id;
            //}

            return Json(new[] { templateStory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStories_Update([DataSourceRequest]DataSourceRequest request, TemplateStory templateStory)
        {
            //if (ModelState.IsValid)
            //{
            var entity = this.stories.GetById(templateStory.Id);
            entity.IsDeleted = templateStory.IsDeleted;
            entity.IsStoryFinished = templateStory.IsStoryFinished;
            entity.Title = templateStory.Title;
            entity.CharacterInTurn = templateStory.CharacterInTurn;
            this.stories.Save();
            // }

            return Json(new[] { templateStory }.ToDataSourceResult(request, ModelState));
        }
    }
}
