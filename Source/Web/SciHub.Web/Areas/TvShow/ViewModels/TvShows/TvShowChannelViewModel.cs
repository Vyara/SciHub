using SciHub.Data.Models.TvShow;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    public class TvShowChannelViewModel : IMapFrom<TvShowChannel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }
}