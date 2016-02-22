namespace SciHub.Web.Areas.ShortStory.ViewModels.Ratings
{
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Data.Models.ShortStory;

    public class ShortStoryRatingViewModel : IMapFrom<ShortStoryRating>
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public int ShortStoryId { get; set; }

        public string UserId { get; set; }

    }
}