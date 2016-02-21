namespace SciHub.Services.Data.DataTransferObjects
{
    using System.Linq;
    using SciHub.Data.Models.Movie;

    public class PagedMoviesDto
    {
        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }

        public IQueryable<Movie> Movies { get; set; }
    }
}
