namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Comments;
    using Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Tags;
    using Data.Models.Book;
    using Data.Models.ShortStory;

    public class ShortStoryDetailsViewModel : IMapFrom<ShortStory>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ShortStoryAuthorViewModel Author { get; set; }

        public string AddedOn { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<ShortStoryCommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ShortStory, ShortStoryDetailsViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.AddedOn, opt => opt.MapFrom(x => x.CreatedOn));
        }
    }
}