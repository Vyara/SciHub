namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Comments;
    using Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Tags;
    using Data.Models.Book;

    public class BookDetailsViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public string Summary { get; set; }

        public BookCover Cover { get; set; }

        public BookAuthorViewModel Author { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<BookCommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Book, BookDetailsViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}