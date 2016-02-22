namespace SciHub.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using SciHub.Common.Constants;
    using SciHub.Web.Controllers;

    [Authorize(Roles = UserRoleConstants.Admin)]
    public abstract class BaseAdminController : BaseController
    {

    }
}