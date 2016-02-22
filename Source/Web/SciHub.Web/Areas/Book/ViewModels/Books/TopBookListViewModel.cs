namespace SciHub.Web.Areas.Book.ViewModels.Books
{
    using System.Collections.Generic;

    public class TopBookListViewModel
    {
        public IEnumerable<TopBookIndexViewModel> Books { get; set; }
    }
}