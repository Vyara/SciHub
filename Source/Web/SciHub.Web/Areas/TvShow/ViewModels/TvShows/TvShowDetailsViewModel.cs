namespace SciHub.Web.Areas.TvShow.ViewModels.TvShows
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using SciHub.Data.Models.Movie;
    using SciHub.Data.Models.TvShow;
    using SciHub.Web.Areas.Movie.ViewModels.Comments;
    using SciHub.Web.Areas.TvShow.ViewModels.Comments;
    using SciHub.Web.Infrastructure.Mapping;
    using SciHub.Web.ViewModels.Actors;
    using SciHub.Web.ViewModels.Directors;
    using SciHub.Web.ViewModels.Tags;
    using SciHub.Data.Models.TvShow;

    public class TvShowDetailsViewModel : IMapFrom<Data.Models.TvShow.TvShow>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int StartYear { get; set; }

        public int? EndYear { get; set; }

        public string Summary { get; set; }

        public TvShowPoster Poster { get; set; }

        public float RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public TvShowChannelViewModel Channel { get; set; }

        public IEnumerable<ActorNameViewModel> Actors { get; set; }

        public IEnumerable<DirectorViewModel> Directors { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<TvShowCommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TvShow, TvShowDetailsViewModel>()
                .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Ratings.Sum(v => v.Value)/x.Ratings.Count()))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}