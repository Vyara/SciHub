namespace SciHub.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models.Movie;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts.Movies;
    using ViewModels;

    public class MoviesController : BaseAdminController
    {
        private readonly IMoviesService movies;

        public MoviesController(IMoviesService movies)
        {
            this.movies = movies;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies_Read([DataSourceRequest]DataSourceRequest request)
        {

            var result = this.movies.GetAll().To<MovieAdminViewModel>().ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Movies_Create([DataSourceRequest]DataSourceRequest request, MovieAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                //var movie = Mapper.Map<Movie>(model);
                var newId = 7;
                var movie = new Movie()
                {
                    Title = model.Title,
                    Year = model.Year,
                    PosterId = model.PosterId,
                    DirectorId = model.DirectorId,
                    StudioId = model.StudioId,
                    Summary = model.Summary,
                    CreatedOn = model.CreatedOn,
                    ModifiedOn = model.ModifiedOn,
                    IsDeleted = model.IsDeleted,
                    DeletedOn = model.DeletedOn

                };

                var result = this.movies.Add(movie);
                newId = movie.Id;
                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Movies_Update([DataSourceRequest]DataSourceRequest request, MovieAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var movie = new Movie()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Year = model.Year,
                    PosterId = model.PosterId,
                    DirectorId = model.DirectorId,
                    StudioId = model.StudioId,
                    Summary = model.Summary,
                    CreatedOn = model.CreatedOn,
                    ModifiedOn = model.ModifiedOn,
                    IsDeleted = model.IsDeleted,
                    DeletedOn = model.DeletedOn

                };

                var result = this.movies.Update(movie).To<MovieAdminViewModel>().FirstOrDefault();
                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Movies_Destroy([DataSourceRequest]DataSourceRequest request, MovieAdminViewModel model)
        {
            var movie = this.movies.GetById(model.Id);
            this.movies.Delete(movie);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}
