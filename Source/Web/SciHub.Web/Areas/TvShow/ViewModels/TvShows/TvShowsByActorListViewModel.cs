using System.Collections.Generic;

namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    public class TvShowsByActorListViewModel
    {
        public IEnumerable<Data.Models.TvShow.TvShow> TvShows { get; set; }
    }
}