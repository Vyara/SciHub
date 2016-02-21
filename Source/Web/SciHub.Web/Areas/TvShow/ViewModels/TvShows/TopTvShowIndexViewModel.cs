using System.Linq;
using AutoMapper;
using SciHub.Data.Models.Movie;
using SciHub.Data.Models.TvShow;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    public class TopTvShowIndexViewModel : IMapFrom<Data.Models.TvShow.TvShow>, IHaveCustomMappings
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

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.TvShow.TvShow, TopTvShowIndexViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value) / x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.LeadActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()))
                .ForMember(x => x.SupportActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Skip(1)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()));

        }

    }
}