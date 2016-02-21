namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TopMovieListViewModel
    {
        public IEnumerable<TopMovieIndexViewModel> Movies { get; set; }
    }
}