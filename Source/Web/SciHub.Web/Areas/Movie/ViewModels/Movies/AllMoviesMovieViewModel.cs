using System.Linq;
using SciHub.Web.Infrastructure.Mapping;

namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System.Collections.Generic;
    using Actors;
    using AutoMapper;
    using Data.Models.Movie;

    public class AllMoviesMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Summary { get; set; }

        public string LeadActor { get; set; }

        public string SupportActor { get; set; }

        public MoviePoster Poster { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public string Director { get; set; }

        public string Studio { get; set; }

        public IEnumerable<ActorNameViewModel> Actors { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, AllMoviesMovieViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value) / x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.LeadActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()))
                .ForMember(x => x.SupportActor, opt => opt.MapFrom(x => x.Actors.OrderByDescending(a => a.CreatedOn)
                .Skip(1)
                .Select(n => new { FullName = n.FirstName + " " + n.LastName })
                .Select(n => n.FullName).FirstOrDefault()))
                 .ForMember(x => x.Director, opt => opt.MapFrom(x => x.Director.FirstName + " " + x.Director.LastName))
                 .ForMember(x => x.Studio, opt => opt.MapFrom(x => x.Studio.Name));
        }
    }
}