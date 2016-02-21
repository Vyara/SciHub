namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System.Linq;
    using AutoMapper;
    using Data.Models.Movie;

    public static class MapBaseMovieViewModel
    {
        public static IMappingExpression<Movie, TDestination> MapBaseViewModel<TDestination>(this IMappingExpression<Movie, TDestination> map)
    where TDestination : TopMovieIndexViewModel
        {
            return map.ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value) / x.Ratings.Count()))
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