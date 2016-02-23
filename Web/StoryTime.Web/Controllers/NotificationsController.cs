namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class NotificationsController : BaseController
    {
        // To get a user notified when he is added to a story or it is his turn
        // GET: Notifications
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
