namespace SciHub.Data.Models.Movie
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class MovieComment : BaseModel<int>
    {
        [Required]
        [MinLength(MovieModelConstants.CommentMinLength)]
        [MaxLength(MovieModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

    }
}
