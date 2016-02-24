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

    public class JokesController : Controller
    {
        private readonly IDbRepository<Joke> jokes;

        public JokesController(IDbRepository<Joke> jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jokes_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.jokes.All().ToDataSourceResult(request, joke => new {
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
            //if (ModelState.IsValid)
            //{
                var entity = new Joke
                {
                    Content = joke.Content,
                    CreatedOn = joke.CreatedOn,
                    ModifiedOn = joke.ModifiedOn,
                    IsDeleted = joke.IsDeleted,
                    DeletedOn = joke.DeletedOn
                };

                this.jokes.Add(entity);
                this.jokes.Save();
                joke.Id = entity.Id;
            //}

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Jokes_Update([DataSourceRequest]DataSourceRequest request, Joke joke)
        {
            // if (ModelState.IsValid)
            // {
            var entity = this.jokes.GetById(joke.Id);
            entity.IsDeleted = joke.IsDeleted;
            entity.Content = joke.Content;
            this.jokes.Save();
            // }

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Jokes_Destroy([DataSourceRequest]DataSourceRequest request, Joke joke)
        {
            //if (ModelState.IsValid)
            //{
                this.jokes.Delete(this.jokes.GetById(joke.Id));
            //}

            return Json(new[] { joke }.ToDataSourceResult(request, ModelState));
        }
    }
}
