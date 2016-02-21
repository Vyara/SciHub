using System.Collections.Generic;

namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    public class TvShowsPageableListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IEnumerable<AllTvShowsTvShowViewModel> TvShows { get; set; }
    }
}