using Microsoft.EntityFrameworkCore;
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
                TotalPages = book.TotalPages,
                UpdateTime = DateTime.UtcNow,
            };
            await _bookStoreContext.Books.AddAsync(newBook);
            await _bookStoreContext.SaveChangesAsync();
            return newBook.Id;
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookStoreContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(_ => _.Title.Contains(title) && _.Author.Contains(authorName));
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id=1,Title="MVC", Author="King",Description="This is about MVC", Category="Programing", Language="English", TotalPages=134},
                new BookModel() { Id=2,Title="C++", Author="Monika",Description= "This is about C++", Category="Talking", Language="Chinese", TotalPages=124},
                new BookModel() { Id=3,Title="C#", Author="Jack",Description= "This is about C#", Category="Cooking", Language="English", TotalPages=1134},
                new BookModel() { Id=4,Title="Java", Author="Laptter",Description= "This is about Java", Category="Design", Language="Japan", TotalPages=2280},
                new BookModel() { Id=5,Title="Php", Author="Lucy",Description= "This is about Php", Category="News", Language="French", TotalPages=880},
            };
        }
    }
}
