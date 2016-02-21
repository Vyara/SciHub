namespace SciHub.Services.Data.Movies
{
    using System.Linq;
    using SciHub.Data.Common.Repositories;
    using Contracts.Movies;
    using SciHub.Data.Models.Movie;

    public class MoviesService : IMoviesService
    {
        private readonly IDbRepository<Movie> movies;

        public MoviesService(IDbRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetTop(int count)
        {
            var ideas = this.movies.All()
                .OrderByDescending(m => (m.Ratings.Sum(r => r.Value) / m.Ratings.Count()))
                .ThenBy(m => m.CreatedOn)
                .Take(count);
            return ideas;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All()
                .OrderByDescending(m => m.CreatedOn);
        }


        public Movie GetById(int id)
        {
            var movie = this.movies.GetById(id);
            return movie;
        }

    }
}
