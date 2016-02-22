namespace SciHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SciHub.Data.Models.Book;
    using SciHub.Services.Data.Contracts;
    using SciHub.Services.Data.DataTransferObjects;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models.Common;

    public class BooksService : IBooksService
    {
        private readonly IDbRepository<Book> books;
        private readonly IDbRepository<BookAuthor> authors;
        private readonly IDbRepository<Tag> tags;


        public BooksService(IDbRepository<Book> books, IDbRepository<BookAuthor> authors, IDbRepository<Tag> tags)
        {
            this.books = books;
            this.authors = authors;
            this.tags = tags;
        }

        public Book Add(Book book)
        {
            book.Ratings.Add(new BookRating()
            {
                Value = 5
            });

            this.books.Add(book);

            this.books.SaveChanges();

            return book;
        }

        public void Delete(Book book)
        {
            this.books.Delete(book);
            this.books.SaveChanges();
        }

        public IQueryable<Book> GetAll()
        {
            return this.books.All()
            .OrderByDescending(m => m.CreatedOn);
        }

        public PagedBooksDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria)
        {
            var allItemsCount = this.books.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var allBooks = this.books.All();

            if (!string.IsNullOrEmpty(criteria))
            {
                allBooks = allBooks.Where(x => x.Title.Contains(criteria) || x.Summary.Contains(criteria));
            }

            if (order == "newest")
            {
                allBooks = allBooks.OrderByDescending(x => x.CreatedOn);
            }
            else if (order == "top")
            {
                allBooks = allBooks.OrderByDescending(m => ((float)m.Ratings.Sum(r => r.Value) / m.Ratings.Count()));
            }

            allBooks = allBooks
                     .Skip(itemsToSkip)
                     .Take(itemsPerPage);

            var dto = new PagedBooksDto
            {
                AllItemsCount = allItemsCount,
                Books = allBooks,
                TotalPages = totalPages
            };

            return dto;
        }

        public ICollection<Book> GetAuthorBooks(int authorId)
        {
            var books = this.authors.GetById(authorId).Books;
            return books;
        }

        public Book GetById(int id)
        {
            var book = this.books.GetById(id);
            return book;
        }

        public ICollection<Book> GetTagBooks(int tagId)
        {
            var books = this.tags.GetById(tagId).Books;
            return books;
        }

        public IQueryable<Book> GetTop(int count)
        {
            var books = this.books.All()
                .OrderByDescending(m => (m.Ratings.Sum(r => r.Value) / m.Ratings.Count()))
                .ThenBy(m => m.CreatedOn)
                .Take(count);
            return books;
        }

        public void Rate(int bookId, float value, string userId)
        {
            var book = this.books.GetById(bookId);

            if (book != null)
            {
                book.Ratings.Add(new BookRating()
                {
                    Value = value,
                    UserId = userId
                });
            }

            this.books.SaveChanges();
        }

        public IQueryable<Book> Update(Book book)
        {
            this.books.Update(book);
            this.books.SaveChanges();

            return this.books.All().Where(m => m.Id == book.Id);
        }
    }
}
