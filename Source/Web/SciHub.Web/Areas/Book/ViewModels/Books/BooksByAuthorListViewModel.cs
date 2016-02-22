namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using System.Collections.Generic;
    using Data.Models.Book;

    public class BooksByAuthorListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}