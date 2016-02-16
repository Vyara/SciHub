namespace SciHub.Data.Models.ShortStory
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants;

    public class ShortStory : BaseModel<int>
    {
        private ICollection<ShortStoryComment> comments;
        private ICollection<ShortStoryRating> ratings;
        private ICollection<ShortStoryTag> tags;

        public ShortStory()
        {
            this.comments = new HashSet<ShortStoryComment>();
            this.ratings = new HashSet<ShortStoryRating>();
            this.tags = new HashSet<ShortStoryTag>();
        }


        [Required]
        [MinLength(DataModelConstants.ShortStoryTitleMinLength)]
        [MaxLength(DataModelConstants.ShortStoryTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataModelConstants.ShortStoryContentMinLength)]
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

        public virtual ICollection<ShortStoryTag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
