namespace SciHub.Web.Areas.ShortStory.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.ShortStories;
    using Web.Controllers;

    public class ShortStoriesController : BaseController
    {
        private readonly IShortStoriesService stories;

        public ShortStoriesController(IShortStoriesService stories)
        {
            this.stories = stories;
        }

        [HttpGet]
        public ActionResult Index(int id = 1, string order = "newest", string criteria = "")
        {
            // Todo: cache

            if (order != "newest" && order != "top")
            {
                // Todo: validate
            }

            var page = id;
            var pagedStories = this.stories.GetAllWithPaging(page, WebConstants.AllShortStoriesPageSize, order, criteria);
            var viewModel = new ShortStoriesPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedStories.AllItemsCount,
                TotalPages = pagedStories.TotalPages,
                ShortStories = pagedStories.ShortStories.To<AllShortStoriesShortStoryViewModel>().AsEnumerable()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var story = this.stories.GetById(id);
            var viewModel = this.Mapper.Map(story, new ShortStoryDetailsViewModel());
            if (story == null)
            {
                return this.Content("Short story with this id was not found");
            }
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Details(int id, float value)
        {
            if (value > 5)
            {
                value = 5;
            }

            if (value < 1)
            {
                value = 1;
            }
            this.stories.Rate(id, value, this.User.Identity.GetUserId());
            return this.RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult ShortStoriesByAuthor(string id)
        {
            // Todo: Cache
  
            var topStories = this.stories.GetAuthorStories(id).ToList();

            var viewModel = new ShortStoriesByAuthorListViewModel
            {
                ShortStories = topStories
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult ShortStoriesByTag(int id)
        {
            // Todo: Cache

            var topStories = this.stories.GetTagStories(id).ToList();

            var viewModel = new ShortStoriesByAuthorListViewModel
            {
                ShortStories = topStories
            };

            return this.View(viewModel);
        }
    }
}