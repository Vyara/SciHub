namespace SciHub.Web.Areas.Book.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants.Models;

    public class BookCommentInputModel
    {
        [Required]
        [MinLength(BookModelConstants.CommentMinLength)]
        [MaxLength(BookModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int BookId { get; set; }
    }
}