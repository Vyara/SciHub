namespace SciHub.Web.Areas.Book.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using System.Linq;
    using SciHub.Services.Data.Contracts;
    using SciHub.Common.Constants;
    using SciHub.Web.Areas.Book.ViewModels.Books;
    using SciHub.Web.Infrastructure.Mapping;

    public class HomeController : BaseController
    {
        private readonly IBooksService books;

        public HomeController(IBooksService books)
        {
            this.books = books;
        }

        public ActionResult Index()
        {
            var topBooks = this.books.GetTop(WebConstants.NumberOfTopBooksForBooksHomePage).To<TopBookIndexViewModel>().ToList();
            var viewModel = new TopBookListViewModel
            {
                Books = topBooks
            };

            return this.View(viewModel);
        }
    }
}