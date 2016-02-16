namespace SciHub.Data.Models.ShortStory
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class ShortStory : BaseModel<int>
    {
        private ICollection<ShortStoryComment> comments;
        private ICollection<ShortStoryRating> ratings;
        private ICollection<Tag> tags;

        public ShortStory()
        {
            this.comments = new HashSet<ShortStoryComment>();
            this.ratings = new HashSet<ShortStoryRating>();
            this.tags = new HashSet<Tag>();
        }


        [Required]
        [MinLength(ShortStoryModelConstants.TitleMinLength)]
        [MaxLength(ShortStoryModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ShortStoryModelConstants.ContentMinLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<ShortStoryComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<ShortStoryRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
