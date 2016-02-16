namespace SciHub.Data.Models.TvShow
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class TvShowRating : BaseModel<int>
    {
        [Required]
        [Range(TvShowModelConstants.RatingMinValue, TvShowModelConstants.RatingMaxValue)]
        public float Value { get; set; }

        public int TvShowId { get; set; }

        public virtual TvShow TvShow { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
