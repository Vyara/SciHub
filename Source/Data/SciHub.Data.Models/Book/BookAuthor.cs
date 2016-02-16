namespace SciHub.Data.Models.Book
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using SciHub.Common.Constants.Models;


    public class BookAuthor : BaseModel<int>
    {
        private ICollection<Book> books;

        public BookAuthor()
        {
            this.books = new HashSet<Book>();
        }

        [Required]
        [MinLength(BookModelConstants.AuthorFirstNameMinLength)]
        [MaxLength(BookModelConstants.AuthorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(BookModelConstants.AuthorLastNameMinLength)]
        [MaxLength(BookModelConstants.AuthorLastNameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
