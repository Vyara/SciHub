namespace SciHub.Web.Areas.Movie.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SciHub.Common.Constants;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Services.Data.Contracts.Movies;
    using SciHub.Web.Areas.Movie.ViewModels.Movies;

    public class HomeController : BaseController
    {
        private readonly IMoviesService movies;

        public HomeController(IMoviesService movies)
        {
            this.movies = movies;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Todo: Cache
            var topMovies = this.movies.GetTop(WebConstants.NumberOfTopMoviesForMoviesHomePage).To<TopMovieIndexViewModel>().ToList();
            var viewModel = new TopMovieListViewModel
            {
                Movies = topMovies
            };

            return this.View(viewModel);
        }
    }
}