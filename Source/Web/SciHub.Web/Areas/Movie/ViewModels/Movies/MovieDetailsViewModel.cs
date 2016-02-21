namespace SciHub.Web.Areas.Movie.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Comments;
    using Data.Models.Movie;
    using Infrastructure.Mapping;
    using Web.ViewModels.Actors;
    using SciHub.Web.ViewModels.Directors;
    using SciHub.Web.ViewModels.Tags;

    public class MovieDetailsViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Summary { get; set; }

        public MoviePoster Poster { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public DirectorViewModel Director { get; set; }

        public MovieStudioViewModel Studio { get; set; }

        public IEnumerable<ActorNameViewModel> Actors { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<MovieCommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}