namespace StoryTime.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using StoryTime.Common;
    using StoryTime.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
