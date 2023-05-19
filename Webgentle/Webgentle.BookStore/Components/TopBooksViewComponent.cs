using Microsoft.AspNetCore.Mvc;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly BookRepository _bookRepository;

        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _bookRepository.GetTopBooks();
            return View(books);
        }
    }
}
