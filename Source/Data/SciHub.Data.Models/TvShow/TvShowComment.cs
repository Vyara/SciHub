namespace SciHub.Data.Models.TvShow
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class TvShowComment : BaseModel<int>
    {
        [Required]
        [MinLength(TvShowModelConstants.CommentMinLength)]
        [MaxLength(TvShowModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int TvShowId { get; set; }

        public virtual TvShow TvShow { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
