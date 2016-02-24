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
    public class TemplateStorySentenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TemplateStorySentences_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<TemplateStorySentence> templatestorysentences = db.TemplateStorySentences;
            DataSourceResult result = templatestorysentences.ToDataSourceResult(request, templateStorySentence => new {
                Id = templateStorySentence.Id,
                Content = templateStorySentence.Content,
                Author = templateStorySentence.Author,
                CreatedOn = templateStorySentence.CreatedOn,
                ModifiedOn = templateStorySentence.ModifiedOn,
                IsDeleted = templateStorySentence.IsDeleted,
                DeletedOn = templateStorySentence.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStorySentences_Create([DataSourceRequest]DataSourceRequest request, TemplateStorySentence templateStorySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new TemplateStorySentence
                {
                    Content = templateStorySentence.Content,
                    Author = templateStorySentence.Author,
                    CreatedOn = templateStorySentence.CreatedOn,
                    ModifiedOn = templateStorySentence.ModifiedOn,
                    IsDeleted = templateStorySentence.IsDeleted,
                    DeletedOn = templateStorySentence.DeletedOn
                };

                db.TemplateStorySentences.Add(entity);
                db.SaveChanges();
                templateStorySentence.Id = entity.Id;
            }

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStorySentences_Update([DataSourceRequest]DataSourceRequest request, TemplateStorySentence templateStorySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new TemplateStorySentence
                {
                    Id = templateStorySentence.Id,
                    Content = templateStorySentence.Content,
                    Author = templateStorySentence.Author,
                    CreatedOn = templateStorySentence.CreatedOn,
                    ModifiedOn = templateStorySentence.ModifiedOn,
                    IsDeleted = templateStorySentence.IsDeleted,
                    DeletedOn = templateStorySentence.DeletedOn
                };

                db.TemplateStorySentences.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStorySentences_Destroy([DataSourceRequest]DataSourceRequest request, TemplateStorySentence templateStorySentence)
        {
            if (ModelState.IsValid)
            {
                var entity = new TemplateStorySentence
                {
                    Id = templateStorySentence.Id,
                    Content = templateStorySentence.Content,
                    Author = templateStorySentence.Author,
                    CreatedOn = templateStorySentence.CreatedOn,
                    ModifiedOn = templateStorySentence.ModifiedOn,
                    IsDeleted = templateStorySentence.IsDeleted,
                    DeletedOn = templateStorySentence.DeletedOn
                };

                db.TemplateStorySentences.Attach(entity);
                db.TemplateStorySentences.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
