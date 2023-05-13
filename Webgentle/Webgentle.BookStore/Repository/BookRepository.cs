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
                new BookModel() { Id=1,Title="MVC", Author="King",Description="This is about MVC", Category="Programing", Language="English", TotalPages=134},
                new BookModel() { Id=2,Title="C++", Author="Monika",Description= "This is about C++", Category="Talking", Language="Chinese", TotalPages=124},
                new BookModel() { Id=3,Title="C#", Author="Jack",Description= "This is about C#", Category="Cooking", Language="English", TotalPages=1134},
                new BookModel() { Id=4,Title="Java", Author="Laptter",Description= "This is about Java", Category="Design", Language="Japan", TotalPages=2280},
                new BookModel() { Id=5,Title="Php", Author="Lucy",Description= "This is about Php", Category="News", Language="French", TotalPages=880},
            };
        }
    }
}
