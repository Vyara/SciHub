namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System.Linq;
    using AutoMapper;
    using Data.Models.Movie;
    using Infrastructure.Mapping;

    public class TopMovieIndexViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Summary { get; set; }

        public string LeadActor { get; set; }

        public string SupportActor { get; set; }

        public MoviePoster Poster { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, TopMovieIndexViewModel>()
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