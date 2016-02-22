namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Data.Models.Book;

    public class TopBookIndexViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public string Summary { get; set; }

        public string Author { get; set; }

        public BookCover Cover { get; set; } 

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Book.Book, TopBookIndexViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.FirstName + " " + x.Author.LastName));
        }

    }
}