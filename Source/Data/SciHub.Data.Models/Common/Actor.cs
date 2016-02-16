namespace SciHub.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using Movie;
    using SciHub.Common.Constants;
    using TvShow;


    public class Actor : BaseModel<int>
    {
        private ICollection<Movie> movies;
        private ICollection<TvShow> tvShows;

        public Actor()
        {
            this.movies = new HashSet<Movie>();
            this.tvShows = new HashSet<TvShow>();
        }

        [Required]
        [MinLength(DataModelConstants.ActorFirstNameMinLength)]
        [MaxLength(DataModelConstants.ActorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataModelConstants.ActorLastNameMinLength)]
        [MaxLength(DataModelConstants.ActorLastNameMaxLength)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<TvShow> TvShows
        {
            get { return this.tvShows; }
            set { this.tvShows = value; }
        }
    }
}
