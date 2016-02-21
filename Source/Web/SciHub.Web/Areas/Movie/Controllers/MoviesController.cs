using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace SciHub.Web.Areas.Movie.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Data.Contracts.Movies;
    using ViewModels.Movies;
    using Web.Controllers;

    public class MoviesController : BaseController
    {
        private readonly IMoviesService movies;

        public MoviesController(IMoviesService movies)
        {
            this.movies = movies;
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
            var pagedMovies = this.movies.GetAllWithPaging(page, WebConstants.AllMoviesPageSize, order, criteria);
            var viewModel = new MoviesPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedMovies.AllItemsCount,
                TotalPages = pagedMovies.TotalPages,
                Movies = pagedMovies.Movies.To<AllMoviesMovieViewModel>().AsEnumerable()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = this.movies.GetById(id);
            var viewModel = this.Mapper.Map(movie, new MovieDetailsViewModel());
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

           this.movies.Rate(id, value, this.User.Identity.GetUserId());
            return this.View();
        }
    }
}