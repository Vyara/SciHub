namespace SciHub.Services.Data.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SciHub.Data.Common.Repositories;
    using Contracts.Movies;
    using DataTransferObjects;
    using SciHub.Data.Models.Common;
    using SciHub.Data.Models.Movie;

    public class MoviesService : IMoviesService
    {
        private readonly IDbRepository<Movie> movies;
        private readonly IDbRepository<Actor> actors;
        private readonly IDbRepository<Director> directors;
        private readonly IDbRepository<Tag> tags;
        private readonly IDbRepository<MovieStudio> studios;

        public MoviesService(IDbRepository<Movie> movies, IDbRepository<Actor> actors, IDbRepository<Tag> tags, IDbRepository<Director> directors, IDbRepository<MovieStudio> studios)
        {
            this.movies = movies;
            this.actors = actors;
            this.directors = directors;
            this.tags = tags;
            this.studios = studios;
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

        public ICollection<Movie> GetActorMovies(int actorId)
        {
            var movies = this.actors.GetById(actorId).Movies;
            return movies;
        }

        public ICollection<Movie> GetTagMovies(int tagId)
        {
            var movies = this.tags.GetById(tagId).Movies;
            return movies;
        }

        public ICollection<Movie> GetStudioMovies(int studioId)
        {
            var movies = this.studios.GetById(studioId).Movies;
            return movies;
        }

        public ICollection<Movie> GetDirectorMovies(int directorId)
        {
            var movies = this.directors.GetById(directorId).Movies;
            return movies;
        }

        public Movie Add(Movie movie)
        {
            movie.Ratings.Add(new MovieRating()
            {
                Value = 5
            });

            this.movies.Add(movie);

            this.movies.SaveChanges();

            return movie;
        }

        public void Delete(Movie movie)
        {
            this.movies.Delete(movie);
            this.movies.SaveChanges();
        }

        public IQueryable<Movie> Update(Movie movie)
        {
            this.movies.Update(movie);
            this.movies.SaveChanges();

            return this.movies.All().Where(m => m.Id == movie.Id);
        }
    }
}
