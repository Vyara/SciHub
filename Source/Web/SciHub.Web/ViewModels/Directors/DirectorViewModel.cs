namespace SciHub.Web.ViewModels.Directors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using SciHub.Data.Models.Common;
    using SciHub.Web.Infrastructure.Mapping;

    public class DirectorViewModel : IMapFrom<Director>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Actor, DirectorViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}