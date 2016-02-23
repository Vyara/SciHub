namespace SciHub.Web.Areas.TvShow.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using SciHub.Common.Constants;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Services.Data.Contracts;
    using SciHub.Web.Areas.TvShow.ViewModels.TvShows;
    using SciHub.Web.Controllers;


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
            var tvShow = this.tvShows.GetById(id);
            var viewModel = this.Mapper.Map(tvShow, new TvShowDetailsViewModel());
            if (tvShow == null)
            {
                return this.Content("Tv Show with this id was not found");
            }
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Details(int id, float value)
        {
            //Todo: check if user already rated this
            if (value > 5)
            {
                value = 5;
            }

            if (value < 1)
            {
                value = 1;
            }
            this.tvShows.Rate(id, value, this.User.Identity.GetUserId());
            return this.RedirectToAction("Details");
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