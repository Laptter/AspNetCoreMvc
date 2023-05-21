using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel book);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooks(int count);
        IEnumerable<BookModel> SearchBook(string title, string authorName);
    }
}