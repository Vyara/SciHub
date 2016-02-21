using System.Collections.Generic;

namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    public class TopTvShowListViewModel
    {
        public IEnumerable<TopTvShowIndexViewModel> TvShows { get; set; }
    }
}