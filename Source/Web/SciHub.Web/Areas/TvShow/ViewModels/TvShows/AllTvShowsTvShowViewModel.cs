namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using SciHub.Data.Models.Movie;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Actors;
    using SciHub.Web.ViewModels.Directors;
    using Data.Models.TvShow;

    public class AllTvShowsTvShowViewModel : IMapFrom<TvShow>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int StartYear { get; set; }

        public int? EndYear { get; set; }

        public string Summary { get; set; }

        public string LeadActor { get; set; }

        public string SupportActor { get; set; }

        public TvShowPoster Poster { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public string Channel { get; set; }

        public IEnumerable<DirectorViewModel> Directors { get; set; }

        public IEnumerable<ActorNameViewModel> Actors { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TvShow, AllTvShowsTvShowViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value) / x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.LeadActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()))
                .ForMember(x => x.SupportActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Skip(1)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()))
                .ForMember(x => x.Channel, opt => opt.MapFrom(x => x.Channel.Name));
        }
    }
}