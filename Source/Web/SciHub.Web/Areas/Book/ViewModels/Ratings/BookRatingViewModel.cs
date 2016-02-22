namespace SciHub.Web.Areas.Book.ViewModels.Ratings
{
    using SciHub.Data.Models.Book;
    using SciHub.Web.Infrastructure.Mapping;

    public class BookRatingViewModel : IMapFrom<BookRating>
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

    }
}