namespace SciHub.Web.ViewModels.Actors
{
    using AutoMapper;
    using Data.Models.Common;
    using Infrastructure.Mapping;

    public class ActorNameViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Actor, ActorNameViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}