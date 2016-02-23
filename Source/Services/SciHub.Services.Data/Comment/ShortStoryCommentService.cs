namespace SciHub.Services.Data.Comment
{
    using System.Linq;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models.ShortStory;
    using SciHub.Services.Data.Contracts;
    using SciHub.Services.Data.Contracts.Comment;

    public class ShortStoryCommentService : IShortStoryCommentsService
    {
        private readonly IDbRepository<ShortStoryComment> shortStoryComments;
        private readonly IUsersService users;

        public ShortStoryCommentService(IDbRepository<ShortStoryComment> shortStoryComments, IUsersService users)
        {
            this.shortStoryComments = shortStoryComments;
            this.users = users;
        }


        public ShortStoryComment Add(string content, int shortStoryId, string userId)
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

            var comment = new ShortStoryComment()
            {
                Content = content,
                ShortStoryId = shortStoryId,
                AuthorId = user.Id
            };

            this.shortStoryComments.Add(comment);
            this.shortStoryComments.SaveChanges();
            return this.shortStoryComments.GetById(comment.Id);
        }

        public void Delete(int id)
        {
            var commentToDelete = this.GetById(id);
            if (commentToDelete == null)
            {
                return;
            }
            this.shortStoryComments.HardDelete(commentToDelete);
            this.shortStoryComments.SaveChanges();
        }

        public IQueryable<ShortStoryComment> GetAll()
        {
            return this.shortStoryComments.All();
        }

        public IQueryable<ShortStoryComment> GetAllByShortStoryId(int shortStoryId, int? size)
        {
            if (size == null || size < 1)
            {
                return this.shortStoryComments
                .All()
                .Where(x => x.ShortStoryId == shortStoryId)
                .OrderByDescending(x => x.CreatedOn);
            }

            return this.shortStoryComments
                .All()
                .Where(x => x.ShortStoryId == shortStoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Take((int)size);
        }

        public ShortStoryComment GetById(int id)
        {
            return this.shortStoryComments.GetById(id);
        }

        public void Update(string content, int id)
        {
            var commentToUpdate = this.GetById(id);
            if (commentToUpdate == null)
            {
                return;
            }

            commentToUpdate.Content = content;

            this.shortStoryComments.SaveChanges();
        }
    }
}
