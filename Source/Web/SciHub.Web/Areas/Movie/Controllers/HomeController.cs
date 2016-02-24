namespace SciHub.Web.Areas.Movie.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SciHub.Common.Constants;
    using SciHub.Services.Data.Contracts;
    using SciHub.Web.Infrastructure.Mapping;
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
            var topMovies = this.movies.GetTop(WebConstants.NumberOfTopMoviesForMoviesHomePage).To<TopMovieIndexViewModel>().ToList();

            var cachedViewModel = this.Cache.Get("TopMovies", () => new TopMovieListViewModel
            {
                Movies = topMovies
            }, WebConstants.MoviesCacheTime);

            return this.View(cachedViewModel);
        }
    }
}