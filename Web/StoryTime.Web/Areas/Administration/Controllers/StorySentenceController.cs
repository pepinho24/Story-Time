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

    public class StorySentenceController : Controller
    {
        private readonly IDbRepository<StorySentence> sentences;

        public StorySentenceController(IDbRepository<StorySentence> sentences)
        {
            this.sentences = sentences;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StorySentences_Read([DataSourceRequest]DataSourceRequest request)
        {

            DataSourceResult result = this.sentences.All().ToDataSourceResult(request, storySentence => new
            {
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

                this.sentences.Add(entity);
                this.sentences.Save();
                storySentence.Id = entity.Id;
            }

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StorySentences_Update([DataSourceRequest]DataSourceRequest request, StorySentence storySentence)
        {
            //if (ModelState.IsValid)
            //{
            var entity = this.sentences.GetById(storySentence.Id);
            entity.IsDeleted = storySentence.IsDeleted;
            entity.Author = storySentence.Author;
            entity.Content = storySentence.Content;

            this.sentences.Save();
            //}

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StorySentences_Destroy([DataSourceRequest]DataSourceRequest request, StorySentence storySentence)
        {
            //if (ModelState.IsValid)
            //{
            this.sentences.Delete(this.sentences.GetById(storySentence.Id));
            //}

            return Json(new[] { storySentence }.ToDataSourceResult(request, ModelState));
        }
    }
}
