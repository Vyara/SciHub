namespace SciHub.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using SciHub.Data.Models.Book;
    using DataTransferObjects;

    public interface IBooksService
    {
        IQueryable<Book> GetTop(int count);

        IQueryable<Book> GetAll();

        PagedBooksDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria);

        Book GetById(int id);

        Book Add(Book book);

        void Delete(Book book);

        IQueryable<Book> Update(Book book);

        void Rate(int bookId, float value, string userId);

        ICollection<Book> GetTagBooks(int tagId);

        ICollection<Book> GetAuthorBooks(int authorId);
    }
}
