namespace SciHub.Services.Data.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Data.Models.Book;

    public class PagedBooksDto
    {
        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IQueryable<Book> Books { get; set; }
    }
}
