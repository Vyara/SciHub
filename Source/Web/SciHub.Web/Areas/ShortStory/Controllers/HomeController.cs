namespace SciHub.Web.Areas.ShortStory.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SciHub.Common.Constants;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Services.Data.Contracts;
    using SciHub.Web.Areas.ShortStory.ViewModels.ShortStories;
    using Web.Controllers;

    public class HomeController : BaseController
    {
        private readonly IShortStoriesService stories;

        public HomeController(IShortStoriesService stories)
        {
            this.stories = stories;
        }

        public ActionResult Index()
        {
            var topStories = this.stories.GetTop(WebConstants.NumberOfTopShortStoriesForShortStoriesHomePage).To<TopShortStoryIndexViewModel>().ToList();
            var viewModel = new TopShortStoryListViewModel
            {
                ShortStories = topStories
            };

            return this.View(viewModel);
        }
    }
}