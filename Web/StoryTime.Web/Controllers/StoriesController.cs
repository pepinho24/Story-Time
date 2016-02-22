﻿namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using StoryTime.Data.Models;
    using StoryTime.Services.Data;
    using StoryTime.Web.ViewModels.Stories;

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
            var stories = this.stories.GetLatestStories(10).ToList();
            return this.View(stories);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int id)
        {
            var story = this.stories.GetById(id);
            return this.View(story);
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
                var storyId = this.stories.Create(model.Title, this.User.Identity.Name).Id;
                return this.RedirectToAction("Details", new { id = storyId });
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
