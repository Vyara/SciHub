namespace SciHub.Data.Models.Movie
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class MovieRating : BaseModel<int>
    {
        [Required]
        [Range(MovieModelConstants.RatingMinValue, MovieModelConstants.RatingMaxValue)]
        public float Value { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
