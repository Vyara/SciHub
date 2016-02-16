namespace SciHub.Data.Models.Movie
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class Movie : BaseModel<int>
    {
        private ICollection<MovieComment> comments;
        private ICollection<MovieRating> ratings;
        private ICollection<Actor> actors;
        private ICollection<Tag> tags;

        public Movie()
        {
            this.comments = new HashSet<MovieComment>();
            this.ratings = new HashSet<MovieRating>();
            this.actors = new HashSet<Actor>();
            this.tags = new HashSet<Tag>();
        }

        [Required]
        [MinLength(MovieModelConstants.TitleMinLength)]
        [MaxLength(MovieModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(MovieModelConstants.YearMinValue, MovieModelConstants.YearMaxValue)]
        public int Year { get; set; }

        [MinLength(MovieModelConstants.SummaryMinLength)]
        [MaxLength(MovieModelConstants.SummaryMaxLength)]
        public string Summary { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int PosterId { get; set; }

        public virtual MoviePoster Poster { get; set; }

        public int StudioId { get; set; }

        public virtual MovieStudio Studio { get; set; }

        public virtual ICollection<MovieComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<MovieRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }


        public virtual ICollection<Actor> Actors
        {
            get { return this.actors; }
            set { this.actors = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
