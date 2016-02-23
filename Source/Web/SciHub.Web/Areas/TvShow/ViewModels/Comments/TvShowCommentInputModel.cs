namespace SciHub.Web.Areas.TvShow.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants.Models;

    public class TvShowCommentInputModel
    {
        [Required]
        [MinLength(TvShowModelConstants.CommentMinLength)]
        [MaxLength(TvShowModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int TvShowId { get; set; }
    }
}