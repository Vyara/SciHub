namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System.Collections.Generic;

    public class MoviesPageableListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AllMoviesMovieViewModel> Movies { get; set; }
    }
}