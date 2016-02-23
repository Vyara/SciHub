using SciHub.Services.Data.Contracts;
using SciHub.Services.Data.Contracts.Comment;

namespace SciHub.Web.Areas.TvShow.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SciHub.Common.Constants;
    using SciHub.Web.Areas.Movie.ViewModels.Movies;
    using SciHub.Web.Areas.TvShow.ViewModels.TvShows;
    using SciHub.Web.Infrastructure.Mapping;


    public class HomeController : BaseController
    {
        private readonly ITvShowsService shows;

        public HomeController(ITvShowsService shows)
        {
            this.shows = shows;
        }

        public ActionResult Index()
        {
            // Todo: Cache
            var topTvshows = this.shows.GetTop(WebConstants.NumberOfTopTvShowsForTvShowsHomePage).To<TopTvShowIndexViewModel>().ToList();
            var viewModel = new TopTvShowListViewModel
            {
                TvShows = topTvshows
            };

            return this.View(viewModel);
        }
    }
}
