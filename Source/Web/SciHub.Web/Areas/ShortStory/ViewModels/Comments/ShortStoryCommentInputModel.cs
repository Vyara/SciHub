namespace SciHub.Web.Areas.ShortStory.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants.Models;

    public class ShortStoryCommentInputModel
    {
        [Required]
        [MinLength(ShortStoryModelConstants.CommentMinLength)]
        [MaxLength(ShortStoryModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int ShortStoryId { get; set; }
    }
}