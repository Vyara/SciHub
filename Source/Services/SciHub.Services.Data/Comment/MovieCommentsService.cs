namespace SciHub.Services.Data.Comment
{
    using System;
    using System.Linq;
    using SciHub.Services.Data.Contracts;
    using SciHub.Services.Data.Contracts.Comment;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models.Movie;

    public class MovieCommentsService : IMovieCommentsService
    {
        private readonly IDbRepository<MovieComment> movieComments;
        private readonly IUsersService users;

        public MovieCommentsService(IDbRepository<MovieComment> movieComments, IUsersService users)
        {
            this.movieComments = movieComments;
            this.users = users;
        }

        public IQueryable<MovieComment> GetAll()
        {
            return this.movieComments.All();
        }

        public IQueryable<MovieComment> GetAllByMovieId(int movieId, int? size)
        {
            if (size == null || size < 1)
            {
                return this.movieComments
                .All()
                .Where(x => x.MovieId == movieId)
                .OrderByDescending(x => x.CreatedOn);
            }

            return this.movieComments
                .All()
                .Where(x => x.MovieId == movieId)
                .OrderByDescending(x => x.CreatedOn)
                .Take((int)size);
        }

        public MovieComment GetById(int id)
        {
            return this.movieComments.GetById(id);
        }

        public MovieComment Add(string content, int movieId, string userId)
        {
            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            var user = this.users.GetById(userId);
            if (user == null)
            {
                return null;
            }

            var comment = new MovieComment()
            {
                Content = content,
                MovieId = movieId,
                AuthorId = user.Id
            };

            this.movieComments.Add(comment);
            this.movieComments.SaveChanges();
            return this.movieComments.GetById(comment.Id);

        }

        public void Update(string content, int id)
        {
            var commentToUpdate = this.GetById(id);
            if (commentToUpdate == null)
            {
                return;
            }

            commentToUpdate.Content = content;

            this.movieComments.SaveChanges();
        }

        public void Delete(int id)
        {
            var commentToDelete = this.GetById(id);
            if (commentToDelete == null)
            {
                return;
            }
            this.movieComments.HardDelete(commentToDelete);
            this.movieComments.SaveChanges();
        }
    }
}
