using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository : IBookRepository
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
                PdfUrl = book.PdfUrl,
            };
            newBook.BookGallery = new List<BookGallery>();
            book.Gallery.ForEach(gallery =>
            {
                newBook.BookGallery.Add(new BookGallery()
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
            var allBooks = await _bookStoreContext.Books.Include(_ => _.BookGallery).ToListAsync();
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
                        CoverImageUrl = book.CoverImageUrl
                    });
                }
            }
            return books;
        }


        public async Task<List<BookModel>> GetTopBooks(int count)
        {
            return await _bookStoreContext
                .Books
                .Include(_ => _.BookGallery)
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Description = book.Description,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    LanguageID = book.LanguageID,
                    Language = book.Language.Name,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl,
                    PdfUrl = book.PdfUrl,
                    Gallery = book.BookGallery.Select(_ => new GalleryModel() { Id = _.Id, Name = _.Name, URL = _.URL }).ToList()
                })
                .Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _bookStoreContext
                .Books
                .Where(_ => _.Id == id)
                .Include(_ => _.BookGallery)
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Description = book.Description,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    LanguageID = book.LanguageID,
                    Language = book.Language.Name,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl,
                    PdfUrl = book.PdfUrl,
                    Gallery = book.BookGallery.Select(_ => new GalleryModel() { Id = _.Id, Name = _.Name, URL = _.URL }).ToList()
                })
                .FirstOrDefaultAsync();
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