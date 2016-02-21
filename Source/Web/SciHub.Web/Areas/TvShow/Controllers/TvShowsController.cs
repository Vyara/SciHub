namespace SciHub.Web.Areas.TvShow.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using SciHub.Common.Constants;
    using SciHub.Services.Data.Contracts.Movies;
    using SciHub.Web.Areas.TvShow.ViewModels.TvShows;
    using SciHub.Web.Controllers;
    using SciHub.Web.Infrastructure.Mapping;

    public class TvShowsController : BaseController
    {
        private readonly ITvShowsService tvShows;

        public TvShowsController(ITvShowsService tvShows)
        {
            this.tvShows = tvShows;
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
            var pagedtvShows = this.tvShows.GetAllWithPaging(page, WebConstants.AllTvShowsPageSize, order, criteria);
            var viewModel = new TvShowsPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedtvShows.AllItemsCount,
                TotalPages = pagedtvShows.TotalPages,
                TvShows = pagedtvShows.TvShows.To<AllTvShowsTvShowViewModel>().AsEnumerable()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = this.tvShows.GetById(id);
            var viewModel = this.Mapper.Map(movie, new TvShowDetailsViewModel());
            if (movie == null)
            {
                return this.Content("Movie with this id was not found");
            }
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Rate(int id)
        {
            return this.PartialView("_RateOptions", id);
        }

        [HttpPost]
        public ActionResult Rate(int id, float value)
        {
            if (value > 5)
            {
                value = 5;
            }

            if (value < 1)
            {
                value = 1;
            }

           this.tvShows.Rate(id, value, this.User.Identity.GetUserId());
            return this.View();
        }

        [HttpGet]
        public ActionResult TvShowsByActor(int id)
        {
            // Todo: Cache
  
            var toptvShows = this.tvShows.GetActorShows(id).ToList();

            var viewModel = new TvShowsByActorListViewModel
            {
                TvShows = toptvShows
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult TvShowsByTag(int id)
        {
            // Todo: Cache

            var toptvShows = this.tvShows.GetTagShows(id).ToList();

            var viewModel = new TvShowsByActorListViewModel
            {
                TvShows = toptvShows
            };

            return this.View(viewModel);
        }


        [HttpGet]
        public ActionResult TvShowsByChannel(int id)
        {
            // Todo: Cache

            var toptvShows = this.tvShows.GetChannelShows(id).ToList();

            var viewModel = new TvShowsByActorListViewModel
            {
                TvShows = toptvShows
            };

            return this.View(viewModel);
        }
    }
}