using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        public IEnumerable<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id) 
        {
            return DataSource().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BookModel> SearchBook(string title,string authorName) 
        {
            return DataSource().Where(_ => _.Title.Contains(title) && _.Author.Contains(authorName));
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id=1,Title="MVC", Author="King"},
                new BookModel() { Id=2,Title="C++", Author="Monika"},
                new BookModel() { Id=3,Title="C#", Author="Jack"},
                new BookModel() { Id=4,Title="Java", Author="Laptter"},
                new BookModel() { Id=5,Title="Php", Author="Lucy"},
            };
        }
    }
}
