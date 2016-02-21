namespace SciHub.Web.Areas.Movie.ViewModels.Ratings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SciHub.Data.Models.Movie;
    using SciHub.Web.Infrastructure.Mapping;

    public class MovieRatingViewModel : IMapFrom<MovieRating>
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }

    }
}