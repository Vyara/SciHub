namespace SciHub.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using SciHub.Services.Data.Contracts;
    using SciHub.Web.Areas.User.ViewModels;
    using SciHub.Web.Controllers;
    using Microsoft.AspNet.Identity;
    using SciHub.Web.Areas.Movie.ViewModels.Comments;
    using Data.Models.ShortStory;
    using SciHub.Web.Areas.ShortStory.ViewModels.ShortStories;
    using System.Linq;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Tags;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUsersService users;
        private readonly IShortStoriesService stories;
        private readonly ITagsService tags;
        public UserController(IUsersService users, IShortStoriesService stories, ITagsService tags)
        {
            this.users = users;
            this.stories = stories;
            this.tags = tags;
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

        [HttpGet]
        public ActionResult CreateStory(string id)
        {
            if (id == null)
            {
                this.Response.StatusCode = 404;
                return this.Content("User was not found");
            }

            var viewModel = new ShortStoryInputViewModel()
            {
                AuthorId = id,
                Tags = this.tags.GetAll().To<TagViewModel>()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStory(ShortStoryInputViewModel shortStory)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.StatusCode = 401;
                return this.Content("Access is denied");
            }

            shortStory.Tags = this.tags.GetAll().To<TagViewModel>();
            shortStory.AuthorId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.View(shortStory);
            }
            var newStory = new ShortStory()
            {
                Title = shortStory.Title,
                Content = shortStory.Content,
                AuthorId = shortStory.AuthorId
            };

            foreach (var id in shortStory.TagIds)
            {
                newStory.Tags.Add(this.tags.GetById(id));
            }

            this.stories.Add(newStory);


            var viewModel = this.Mapper.Map<ShortStoryDetailsViewModel>(newStory);


            return this.RedirectToAction("Details", "ShortStories", new { id = viewModel.Id, area = "ShortStory" });
        }

    }
}