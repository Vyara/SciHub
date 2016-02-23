namespace SciHub.Services.Data.Comment
{
    using System.Linq;
    using SciHub.Services.Data.Contracts;
    using SciHub.Data.Models.TvShow;
    using SciHub.Data.Common.Repositories;

    public class TvShowCommentsService : ITvShowCommentsService
    {
        private readonly IDbRepository<TvShowComment> tvShowComments;
        private readonly IUsersService users;

        public TvShowCommentsService(IDbRepository<TvShowComment> tvShowComments, IUsersService users)
        {
            this.tvShowComments = tvShowComments;
            this.users = users;
        }

        public TvShowComment Add(string content, int showId, string userId)
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

            var comment = new TvShowComment()
            {
                Content = content,
                TvShowId = showId,
                AuthorId = user.Id
            };

            this.tvShowComments.Add(comment);
            this.tvShowComments.SaveChanges();
            return this.tvShowComments.GetById(comment.Id);
        }

        public void Delete(int id)
        {
            var commentToDelete = this.tvShowComments.GetById(id);
            if (commentToDelete == null)
            {
                return;
            }
            this.tvShowComments.HardDelete(commentToDelete);
            this.tvShowComments.SaveChanges();
        }

        public IQueryable<TvShowComment> GetAll()
        {
            return this.tvShowComments.All();
        }

        public IQueryable<TvShowComment> GetAllByTvShowId(int showId, int? size)
        {
            if (size == null || size < 1)
            {
                return this.tvShowComments
                .All()
                .Where(x => x.TvShowId == showId)
                .OrderByDescending(x => x.CreatedOn);
            }

            return this.tvShowComments
                .All()
                .Where(x => x.TvShowId == showId)
                .OrderByDescending(x => x.CreatedOn)
                .Take((int)size);
        }

        public TvShowComment GetById(int id)
        {
            return this.tvShowComments.GetById(id);
        }

        public void Update(string content, int id)
        {
            var commentToUpdate = this.GetById(id);
            if (commentToUpdate == null)
            {
                return;
            }

            commentToUpdate.Content = content;

            this.tvShowComments.SaveChanges();
        }
    }
}



