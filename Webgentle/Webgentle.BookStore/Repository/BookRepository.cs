using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<int> AddNewBook(BookModel book)
        {
            var newBook = new Book()
            {
                Author = book.Author,
                CreateTime = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                LanguageID = book.LanguageID.Value,
                TotalPages = book.TotalPages.HasValue ? book.TotalPages.Value : 0,
                UpdateTime = DateTime.UtcNow,
                CoverImageUrl = book.CoverImageUrl,
            };
            newBook.BookGalleries = new List<BookGallery>();
            book.Gallery.ForEach(gallery =>
            {
                newBook.BookGalleries.Add(new BookGallery()
                {
                    BookId = gallery.Id,
                    Name = gallery.Name,
                    URL = gallery.URL,
                });
            });

            await _bookStoreContext.Books.AddAsync(newBook);
            await _bookStoreContext.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var allBooks = await _bookStoreContext.Books.ToListAsync();
            var allLanguages = await _bookStoreContext.Languagess.ToListAsync();
            var books = new List<BookModel>();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {

                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Description = book.Description,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        LanguageID = book.LanguageID,
                        Language = allLanguages.FirstOrDefault(_ => _.Id == book.LanguageID)?.Name,
                        Category = book.Category,
                        CoverImageUrl = book.CoverImageUrl,

                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _bookStoreContext.Books.FindAsync(id);
            var allLanguages = await _bookStoreContext.Languagess.ToListAsync();
            if (book != null)
            {
                var list = new List<GalleryModel>();
                list.AddRange(book.BookGalleries.Select(_ => new GalleryModel() { Id = _.Id, Name = _.Name, URL = _.URL }));
                return new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Description = book.Description,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    LanguageID = book.LanguageID,
                    Language = allLanguages.FirstOrDefault(_ => _.Id == book.LanguageID)?.Name,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = list
                };
            }
            return null;
        }

        public IEnumerable<BookModel> SearchBook(string title, string authorName)
        {
            var allBooks = _bookStoreContext.Books.Where(_ => _.Title.Contains(title) && _.Author.Contains(authorName));
            var books = new List<BookModel>();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Description = book.Description,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        LanguageID = book.LanguageID,
                        Category = book.Category,
                    });
                }
            }
            return books;
        }
    }
}
