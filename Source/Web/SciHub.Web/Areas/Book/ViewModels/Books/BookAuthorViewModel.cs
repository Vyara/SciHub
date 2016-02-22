namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using AutoMapper;
    using SciHub.Data.Models.Book;
    using SciHub.Web.Infrastructure.Mapping;

    public class BookAuthorViewModel : IMapFrom<BookAuthor>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BookAuthor, BookAuthorViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }

    }
}