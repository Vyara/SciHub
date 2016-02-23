namespace SciHub.Web.Areas.Movie.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants.Models;

    public class MovieCommentInputModel
    {
        [Required]
        [MaxLength(MovieModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int MovieId { get; set; }
    }
}