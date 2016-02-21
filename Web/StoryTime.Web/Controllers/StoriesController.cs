using StoryTime.Data.Models;
using StoryTime.Services.Data;
using StoryTime.Web.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoryTime.Web.Controllers
{
    public class StoriesController : BaseController
    {
        private readonly IStoriesService stories;

        public StoriesController(IStoriesService stories)
        {
            this.stories = stories;
        }

        // GET: Stories
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Stories/Details/5
        public ActionResult Details(int id)
        {
            var story = this.stories.GetById(id);
            return this.View(story);
        }

        // POST: Stories/Details/5
        [HttpPost]
        [Authorize]
        public ActionResult AddSentence(string id, string model)
        {
            var intId = int.Parse(id);
            this.stories.AddSentence(intId, model, this.User.Identity.Name);

            return this.RedirectToAction("Details", new { id = id });
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Stories/Create
        [HttpPost]
        public ActionResult Create(StoryInputModel model)
        {
            try
            {
                var storyId = this.stories.Create(model.Title).Id;
                return this.RedirectToAction("Details", new { id = storyId });
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int id)
        {

            return this.View();
        }

        // POST: Stories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Stories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}
