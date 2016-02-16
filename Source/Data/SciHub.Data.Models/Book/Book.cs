namespace SciHub.Data.Models.Book
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;

    public class Book : BaseModel<int>
    {
        private ICollection<BookComment> comments;
        private ICollection<BookRating> ratings;
        private ICollection<BookTag> tags;

        public Book()
        {
            this.comments = new HashSet<BookComment>();
            this.ratings = new HashSet<BookRating>();
            this.tags = new HashSet<BookTag>();
        }

        [Required]
        [MinLength(BookModelConstants.TitleMinLength)]
        [MaxLength(BookModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(BookModelConstants.PublicationYearMinValue, BookModelConstants.PublicationYearMaxValue)]
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }

        public virtual BookAuthor Author { get; set; }

        public int CoverId { get; set; }

        public virtual BookCover Cover { get; set; }

        public virtual ICollection<BookComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<BookRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<BookTag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }


    }
}
