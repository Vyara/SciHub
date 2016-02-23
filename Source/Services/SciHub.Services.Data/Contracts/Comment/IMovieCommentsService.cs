namespace SciHub.Services.Data.Contracts.Comment
{
    using System.Linq;
    using SciHub.Data.Models.Movie;

    public interface IMovieCommentsService
    {
        IQueryable<MovieComment> GetAll();

        IQueryable<MovieComment> GetAllByMovieId(int movieId, int? size);

        MovieComment GetById(int id);

        MovieComment Add(string content, int movieId, string userId);

        void Update(string content, int id);

        void Delete(int id);

    }
}
