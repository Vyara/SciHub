namespace SciHub.Data.Models.Book
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class BookComment : BaseModel<int>
    {
        [Required]
        [MinLength(BookModelConstants.CommentMinLength)]
        [MaxLength(BookModelConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

    }
}
