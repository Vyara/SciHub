namespace SciHub.Web.Areas.TvShow.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System.Linq;
    using SciHub.Common.Constants;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Services.Data.Contracts.Comment;
    using SciHub.Web.Areas.TvShow.ViewModels.TvShows;

    public class HomeController : BaseController
    {
        private readonly ITvShowsService shows;

        public HomeController(ITvShowsService shows)
        {
            this.shows = shows;
        }

        public ActionResult Index()
        {
            var topTvshows = this.shows.GetTop(WebConstants.NumberOfTopTvShowsForTvShowsHomePage).To<TopTvShowIndexViewModel>().ToList();
            var cachedViewModel = this.Cache.Get("TopTvShows", () => new TopTvShowListViewModel
            {
                TvShows = topTvshows
            }, WebConstants.BooksCacheTime);

            return this.View(cachedViewModel);
        }
    }
}
