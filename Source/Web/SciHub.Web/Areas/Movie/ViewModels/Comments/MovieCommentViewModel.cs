namespace SciHub.Web.Areas.Movie.ViewModels.Comments
{
    using System;
    using AutoMapper;
    using Data.Models.Movie;
    using Infrastructure.Mapping;

    public class MovieCommentViewModel : IMapFrom<MovieComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MovieComment, MovieCommentViewModel>()
               .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

        }
    }
}