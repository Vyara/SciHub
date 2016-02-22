namespace SciHub.Services.Data.Contracts.Movies
{
    using System.Collections.Generic;
    using SciHub.Services.Data.DataTransferObjects;
    using System.Linq;
    using SciHub.Data.Models.Movie;

    public interface IMoviesService
    {
        IQueryable<Movie> GetTop(int count);

        IQueryable<Movie> GetAll();

        PagedMoviesDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria);

        Movie GetById(int id);

        Movie Add(Movie movie);

        void Delete(Movie movie);

        IQueryable<Movie> Update(Movie movie);

        void Rate(int movieId, float value, string userId);

        ICollection<Movie> GetActorMovies(int actorId);

        ICollection<Movie> GetTagMovies(int tagId);

        ICollection<Movie> GetStudioMovies(int studioId);


        ICollection<Movie> GetDirectorMovies(int directorId);

    }
}
