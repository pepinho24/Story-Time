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

    public class TemplateStorySentenceController : Controller
    {
        private readonly IDbRepository<TemplateStorySentence> sentences;

        public TemplateStorySentenceController(IDbRepository<TemplateStorySentence> sentences)
        {
            this.sentences = sentences;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TemplateStorySentences_Read([DataSourceRequest]DataSourceRequest request)
        {
             DataSourceResult result = this.sentences.All().ToDataSourceResult(request, templateStorySentence => new {
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

                this.sentences.Add(entity);
                this.sentences.Save();
                templateStorySentence.Id = entity.Id;
            }

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStorySentences_Update([DataSourceRequest]DataSourceRequest request, TemplateStorySentence templateStorySentence)
        {
            //if (ModelState.IsValid)
            //{
            var entity = this.sentences.GetById(templateStorySentence.Id);
            entity.Author = templateStorySentence.Author;
            entity.Content = templateStorySentence.Content;
            entity.IsDeleted = templateStorySentence.IsDeleted;

            this.sentences.Save();
            //}

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TemplateStorySentences_Destroy([DataSourceRequest]DataSourceRequest request, TemplateStorySentence templateStorySentence)
        {
            if (ModelState.IsValid)
            {
                this.sentences.Delete(this.sentences.GetById(templateStorySentence.Id));
            }

            return Json(new[] { templateStorySentence }.ToDataSourceResult(request, ModelState));
        }
    }
}
