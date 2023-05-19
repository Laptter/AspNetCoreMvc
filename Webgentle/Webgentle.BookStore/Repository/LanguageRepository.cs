using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Data;

namespace Webgentle.BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public LanguageRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return await _bookStoreContext.Languagess.ToListAsync();
        }
    }
}