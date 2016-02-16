namespace SciHub.Data.Models.ShortStory
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants;

    public class ShortStoryComment : BaseModel<int>
    {
        [Required]
        [MinLength(DataModelConstants.ShortStoryCommentMinLength)]
        [MaxLength(DataModelConstants.ShortStoryCommentMaxLength)]
        public string Content { get; set; }

        public int ShortStoryId { get; set; }

        public virtual ShortStory ShortStory { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

    }
}
