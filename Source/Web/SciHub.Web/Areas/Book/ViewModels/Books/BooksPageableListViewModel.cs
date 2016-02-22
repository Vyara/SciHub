namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using System.Collections.Generic;

    public class BooksPageableListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IEnumerable<AllBooksBookViewModel> Books { get; set; }
    }
}