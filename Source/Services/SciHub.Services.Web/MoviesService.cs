namespace SciHub.Services.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Services.Web.Contracts;
    using Data.Common.Repositories;
    using Data.Models.Movie;

    public class MoviesService : IMoviesService
    {
        private readonly IDbRepository<Movie> movies;

        public MoviesService(IDbRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetTop(int count)
        {
           return this.movies.All().OrderBy(m => m.Ratings).ThenBy(m => m.CreatedOn).Take(count);
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All().OrderByDescending(m => m.CreatedOn);
        }


        public Movie GetById(int id)
        {
            var movie = this.movies.GetById(id);
            return movie;
        }

    }
}
