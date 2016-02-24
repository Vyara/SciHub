namespace SciHub.Web.Areas.Movie.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Services.Data.Contracts.Comment;
    using ViewModels.Comments;
    using ViewModels.Movies;
    using Web.Controllers;


    public class MoviesController : BaseController
    {
        private readonly IMoviesService movies;
        private readonly IMovieCommentsService comments;

        public MoviesController(IMoviesService movies, IMovieCommentsService comments)
        {
            this.movies = movies;
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
            var pagedMovies = this.movies.GetAllWithPaging(page, WebConstants.AllMoviesPageSize, order, criteria);
            var viewModel = new MoviesPageableListViewModel()
            {
                CurrentPage = page,
                AllItemsCount = pagedMovies.AllItemsCount,
                TotalPages = pagedMovies.TotalPages,
                Movies = pagedMovies.Movies.To<AllMoviesMovieViewModel>().ToList()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = this.movies.GetById(id);
            var viewModel = this.Mapper.Map(movie, new MovieDetailsViewModel());
            if (movie == null)
            {
                this.Response.StatusCode = 404;
                return this.Content("Movie with this id was not found");
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
            this.movies.Rate(id, value, this.User.Identity.GetUserId());
            return this.RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult MoviesByActor(int id)
        {

            var topMovies = this.movies.GetActorMovies(id).ToList();

            var viewModel = new MoviesByActorListViewModel
            {
                Movies = topMovies
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult MoviesByTag(int id)
        {

            var topMovies = this.movies.GetTagMovies(id).ToList();

            var viewModel = new MoviesByActorListViewModel
            {
                Movies = topMovies
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult MoviesByDirector(int id)
        {

            var topMovies = this.movies.GetDirectorMovies(id).ToList();

            var viewModel = new MoviesByActorListViewModel
            {
                Movies = topMovies
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult MoviesByStudio(int id)
        {

            var topMovies = this.movies.GetStudioMovies(id).ToList();

            var viewModel = new MoviesByActorListViewModel
            {
                Movies = topMovies
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            var viewModel = new MovieCommentInputModel()
            {
                Content = string.Empty,
                MovieId = id

            };
            return this.PartialView("_AddComment", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(MovieCommentInputModel comment)
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

            var newComment = this.comments.Add(comment.Content, comment.MovieId, this.User.Identity.GetUserId());
            if (newComment == null)
            {
                this.Response.StatusCode = 400;
                return this.Content("Bad request.");
            }

            var viewModel = this.Mapper.Map<MovieCommentViewModel>(newComment);

            return this.PartialView("_MovieComment", viewModel);
        }
    }
}