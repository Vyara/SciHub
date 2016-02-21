using SciHub.Data.Models.TvShow;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.TvShow.ViewModels.Ratings
{
    public class TvShowRatingViewModel : IMapFrom<TvShowRating>
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public int TvShowId { get; set; }

        public string UserId { get; set; }

    }
}