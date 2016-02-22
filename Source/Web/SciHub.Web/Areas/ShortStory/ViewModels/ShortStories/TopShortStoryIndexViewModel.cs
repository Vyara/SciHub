namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Data.Models.ShortStory;

    public class TopShortStoryIndexViewModel : IMapFrom<ShortStory>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AddedOn { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ShortStory, TopShortStoryIndexViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.AddedOn, opt => opt.MapFrom(x => x.CreatedOn));
        }

    }
}