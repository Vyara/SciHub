namespace SciHub.Data.Models.ShortStory
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;


    public class ShortStoryRating : BaseModel<int>
    {
        [Required]
        [Range(ShortStoryModelConstants.RatingMinValue, ShortStoryModelConstants.RatingMaxValue)]
        public float Value { get; set; }

        public int ShortStoryId { get; set; }

        public virtual ShortStory ShortStory { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }


    }
}
