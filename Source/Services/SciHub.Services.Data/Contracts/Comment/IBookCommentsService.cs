namespace SciHub.Services.Data.Contracts.Comment
{
    using System.Linq;
    using SciHub.Data.Models.Book;

    public interface IBookCommentsService 
    {
        IQueryable<BookComment> GetAll();

        IQueryable<BookComment> GetAllByBookId(int bookId, int? size);

        BookComment GetById(int id);

        BookComment Add(string content, int bookId, string userId);

        void Update(string content, int id);

        void Delete(int id);
    }
}
