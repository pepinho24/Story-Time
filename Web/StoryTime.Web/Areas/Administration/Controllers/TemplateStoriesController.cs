﻿using System;
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

namespace StoryTime.Web.Areas.Administration.Controllers
{
    public class TemplateStoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TemplateStories_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<TemplateStory> templatestories = db.TemplateStories;
            DataSourceResult result = templatestories.ToDataSourceResult(request, templateStory => new {
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
            if (ModelState.IsValid)
            {
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

                db.TemplateStories.Add(entity);
                db.SaveChanges();
                templateStory.Id = entity.Id;
            }

            return Json(new[] { templateStory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStories_Update([DataSourceRequest]DataSourceRequest request, TemplateStory templateStory)
        {
            if (ModelState.IsValid)
            {
                var entity = new TemplateStory
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
                };

                db.TemplateStories.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { templateStory }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
