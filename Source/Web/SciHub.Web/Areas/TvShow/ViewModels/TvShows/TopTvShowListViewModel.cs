namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    using System.Collections.Generic;

    public class TopTvShowListViewModel
    {
        public IEnumerable<TopTvShowIndexViewModel> TvShows { get; set; }
    }
}