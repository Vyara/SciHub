using System.ComponentModel.DataAnnotations.Schema;

namespace SciHub.Data.Models.TvShow
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class TvShow : BaseModel<int>
    {
        private ICollection<TvShowComment> comments;
        private ICollection<TvShowRating> ratings;
        private ICollection<Actor> actors;
        private ICollection<Director> directors;
        private ICollection<Tag> tags;

        public TvShow()
        {
            this.comments = new HashSet<TvShowComment>();
            this.ratings = new HashSet<TvShowRating>();
            this.actors = new HashSet<Actor>();
            this.directors = new HashSet<Director>();
            this.tags = new HashSet<Tag>();
        }

        [Required]
        [MinLength(TvShowModelConstants.TitleMinLength)]
        [MaxLength(TvShowModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(TvShowModelConstants.StartYearMinValue, TvShowModelConstants.StartYearMaxValue)]
        public int StartYear { get; set; }

        [Required]
        [Range(TvShowModelConstants.EndYearMinValue, TvShowModelConstants.EndYearMaxValue)]
        public int EndYear { get; set; }

        [MinLength(TvShowModelConstants.SummaryMinLength)]
        [MaxLength(TvShowModelConstants.SummaryMaxLength)]
        public string Summary { get; set; }

        public int TvShowPosterId { get; set; }

        public int ChannelId { get; set; }

        public virtual TvShowChannel Channel { get; set; }

        public virtual ICollection<TvShowComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<TvShowRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }


        public virtual ICollection<Actor> Actors
        {
            get { return this.actors; }
            set { this.actors = value; }
        }

        public virtual ICollection<Director> Directors
        {
            get { return this.directors; }
            set { this.directors = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
