namespace SciHub.Data.Models.Book
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class BookRating : BaseModel<int>
    {
        [Required]
        [Range(BookModelConstants.RatingMinValue, BookModelConstants.RatingMaxValue)]
        public float Value { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
