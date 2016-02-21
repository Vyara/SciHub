namespace SciHub.Services.Data.Movies
{
    using System;

    using System.Linq;
    using SciHub.Data.Common.Repositories;
    using Contracts.Movies;
    using DataTransferObjects;
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

        public PagedMoviesDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria)
        {
            var allItemsCount = this.movies.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var allMovies = this.movies.All();

            if (!string.IsNullOrEmpty(criteria))
            {
                allMovies = allMovies.Where(x => x.Title.Contains(criteria) || x.Summary.Contains(criteria));
            }

            if (order == "newest")
            {
                allMovies = allMovies.OrderByDescending(x => x.CreatedOn);
            }
            else if (order == "top")
            {
                allMovies = allMovies.OrderByDescending(m => ((float)m.Ratings.Sum(r => r.Value) / m.Ratings.Count()));
            }

            allMovies = allMovies
                     .Skip(itemsToSkip)
                     .Take(itemsPerPage);

            var dto = new PagedMoviesDto
            {
                AllItemsCount = allItemsCount,
                Movies = allMovies,
                TotalPages = totalPages
            };

            return dto;
        }

        public void Rate(int movieId, float value, string userId)
        {
            var movie = this.movies.GetById(movieId);

            if (movie != null)
            {
                movie.Ratings.Add(new MovieRating()
                {
                    Value = value,
                    UserId = userId
                });
            }

            this.movies.SaveChanges();
        }

        public Movie GetById(int id)
        {
            var movie = this.movies.GetById(id);
            return movie;
        }

    }
}
