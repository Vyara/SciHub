namespace SciHub.Web.Areas.Book.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using SciHub.Services.Data.Contracts.Comment;
    using ViewModels.Books;
    using SciHub.Web.Areas.Book.ViewModels.Comments;
    using Web.Controllers;

    public class BooksController : BaseController
    {
        private readonly IBooksService books;
        private readonly IBookCommentsService comments;

        public BooksController(IBooksService books, IBookCommentsService comments)
        {
            this.books = books;
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult Index(int id = 1, string order = "newest", string criteria = "")
        {


            if (order != "newest" && order != "top")
            {
                this.Response.StatusCode = 412;
                return this.Content("Order not right");
            }

            var page = id;
            var pagedBooks = this.books.GetAllWithPaging(page, WebConstants.AllBooksPageSize, order, criteria);

            var cachedViewModel = this.Cache.Get("booksPaged", () => new BooksPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedBooks.AllItemsCount,
                TotalPages = pagedBooks.TotalPages,
                Books = pagedBooks.Books.To<AllBooksBookViewModel>().ToList()
            }, WebConstants.BooksCacheTime);

            return this.View(cachedViewModel);
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

        [Authorize]
        [HttpPost]
        public ActionResult Details(int id, float value)
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
            return this.RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult BooksByAuthor(int id)
        {

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

            var topBooks = this.books.GetTagBooks(id).ToList();

            var viewModel = new BooksByAuthorListViewModel
            {
                Books = topBooks
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            var viewModel = new BookCommentInputModel()
            {
                Content = string.Empty,
                BookId = id

            };
            return this.PartialView("_AddComment", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(BookCommentInputModel comment)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.StatusCode = 401;
                return this.Content("Access is denied");
            }

            if (comment == null || !this.ModelState.IsValid)
            {
                this.Response.StatusCode = 400;
                return this.Content("Bad request");
            }

            var newComment = this.comments.Add(comment.Content, comment.BookId, this.User.Identity.GetUserId());
            if (newComment == null)
            {
                this.Response.StatusCode = 400;
                return this.Content("Bad request.");
            }

            var viewModel = this.Mapper.Map<BookCommentViewModel>(newComment);

            return this.PartialView("_BookComment", viewModel);
        }
    }
}