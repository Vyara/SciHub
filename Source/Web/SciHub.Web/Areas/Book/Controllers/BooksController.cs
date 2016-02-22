namespace SciHub.Web.Areas.Book.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Books;
    using Web.Controllers;

    public class BooksController : BaseController
    {
        private readonly IBooksService books;

        public BooksController(IBooksService books)
        {
            this.books = books;
        }

        [HttpGet]
        public ActionResult Index(int id = 1, string order = "newest", string criteria = "")
        {
            // Todo: cache

            if (order != "newest" && order != "top")
            {
                // Todo: validate
            }

            var page = id;
            var pagedBooks = this.books.GetAllWithPaging(page, WebConstants.AllBooksPageSize, order, criteria);
            var viewModel = new BooksPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedBooks.AllItemsCount,
                TotalPages = pagedBooks.TotalPages,
                Books = pagedBooks.Books.To<AllBooksBookViewModel>().AsEnumerable()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var book = this.books.GetById(id);
            var viewModel = this.Mapper.Map(book, new BookDetailsViewModel());
            if (book == null)
            {
                return this.Content("Book with this id was not found");
            }
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Rate(int id)
        {
            return this.PartialView("_RateOptions", id);
        }

        [HttpPost]
        public ActionResult Rate(int id, float value)
        {
            if (value > 5)
            {
                value = 5;
            }

            if (value < 1)
            {
                value = 1;
            }

           this.books.Rate(id, value, this.User.Identity.GetUserId());
            return this.View();
        }

        [HttpGet]
        public ActionResult BooksByAuthor(int id)
        {
            // Todo: Cache
  
            var topBooks = this.books.GetAuthorBooks(id).ToList();

            var viewModel = new BooksByAuthorListViewModel
            {
                Books = topBooks
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult BooksByTag(int id)
        {
            // Todo: Cache

            var topBooks = this.books.GetTagBooks(id).ToList();

            var viewModel = new BooksByAuthorListViewModel
            {
                Books = topBooks
            };

            return this.View(viewModel);
        }
    }
}