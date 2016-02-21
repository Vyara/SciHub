namespace SciHub.Services.Data.Contracts.Movies
{
    using System.Linq;
    using SciHub.Data.Models.Movie;

    public interface IMoviesService
    {
        IQueryable<Movie> GetTop(int count);

        IQueryable<Movie> GetAll();

        Movie GetById(int id);

    }
}
