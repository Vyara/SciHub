namespace SciHub.Data.Models.ShortStory
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class ShortStoryComment : BaseModel<int>
    {
        [Required]
        [MinLength(ShortStoryModelConstants.CommentMinLength)]
        [MaxLength(ShortStoryModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int ShortStoryId { get; set; }

        public virtual ShortStory ShortStory { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

    }
}
