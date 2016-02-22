namespace SciHub.Web.Areas.ShortStory.ViewModels.ShortStories
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ShortStoryAuthorViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, ShortStoryAuthorViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.UserName));
        }

    }
}