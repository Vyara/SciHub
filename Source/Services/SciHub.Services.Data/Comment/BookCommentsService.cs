namespace SciHub.Services.Data.Comment
{
    using System.Linq;
    using SciHub.Services.Data.Contracts;
    using SciHub.Services.Data.Contracts.Comment;
    using SciHub.Data.Models.Book;
    using SciHub.Data.Common.Repositories;


    public class BookCommentsService : IBookCommentsService
    {
        private readonly IDbRepository<BookComment> bookComments;
        private readonly IUsersService users;

        public BookCommentsService(IDbRepository<BookComment> bookComments, IUsersService users)
        {
            this.bookComments = bookComments;
            this.users = users;
        }


        public BookComment Add(string content, int bookId, string userId)
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

            var comment = new BookComment()
            {
                Content = content,
                BookId = bookId,
                AuthorId = user.Id
            };

            this.bookComments.Add(comment);
            this.bookComments.SaveChanges();
            return this.bookComments.GetById(comment.Id);
        }

        public void Delete(int id)
        {
            var commentToDelete = this.GetById(id);
            if (commentToDelete == null)
            {
                return;
            }
            this.bookComments.HardDelete(commentToDelete);
            this.bookComments.SaveChanges();
        }

        public IQueryable<BookComment> GetAll()
        {
            return this.bookComments.All();
        }

        public IQueryable<BookComment> GetAllByBookId(int bookId, int? size)
        {
            if (size == null || size < 1)
            {
                return this.bookComments
                .All()
                .Where(x => x.BookId == bookId)
                .OrderByDescending(x => x.CreatedOn);
            }

            return this.bookComments
                .All()
                .Where(x => x.BookId == bookId)
                .OrderByDescending(x => x.CreatedOn)
                .Take((int)size);
        }

        public BookComment GetById(int id)
        {
            return this.bookComments.GetById(id);
        }

        public void Update(string content, int id)
        {
            var commentToUpdate = this.GetById(id);
            if (commentToUpdate == null)
            {
                return;
            }

            commentToUpdate.Content = content;

            this.bookComments.SaveChanges();
        }
    }
}
