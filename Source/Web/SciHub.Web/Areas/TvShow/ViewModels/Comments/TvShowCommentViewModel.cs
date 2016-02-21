using System;
using AutoMapper;
using SciHub.Data.Models.TvShow;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.TvShow.ViewModels.Comments
{
    public class TvShowCommentViewModel : IMapFrom<TvShowComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TvShowComment, TvShowCommentViewModel>()
               .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

        }
    }
}