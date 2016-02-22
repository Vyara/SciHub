namespace SciHub.Web.Areas.ShortStory.ViewModels.Comments
{
    using System;
    using AutoMapper;
    using Data.Models.Book;
    using SciHub.Data.Models.ShortStory;
    using Infrastructure.Mapping;

    public class ShortStoryCommentViewModel : IMapFrom<ShortStoryComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ShortStoryComment, ShortStoryCommentViewModel>()
               .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

        }
    }
}