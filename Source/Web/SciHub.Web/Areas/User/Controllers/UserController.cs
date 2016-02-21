namespace SciHub.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using SciHub.Services.Data.Contracts;
    using SciHub.Web.Areas.User.ViewModels;
    using SciHub.Web.Controllers;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUsersService users;

        public UserController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUser = this.users.GetUser(this.User.Identity.Name);
            var viewModel = new UserDetailsViewModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Avatar = currentUser.Avatar,
                About = currentUser.About
            };

            return this.View(viewModel);
        }

    }
}