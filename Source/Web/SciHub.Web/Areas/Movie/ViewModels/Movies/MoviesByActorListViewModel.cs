namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System.Collections.Generic;
    using Data.Models.Movie;

    public class MoviesByActorListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}