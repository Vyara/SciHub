namespace SciHub.Web.Areas.Book.ViewModels.Comments
{
    using System;
    using AutoMapper;
    using Data.Models.Book;
    using Infrastructure.Mapping;

    public class BookCommentViewModel : IMapFrom<BookComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BookComment, BookCommentViewModel>()
               .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

        }
    }
}