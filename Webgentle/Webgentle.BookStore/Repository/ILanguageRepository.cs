using Webgentle.BookStore.Data;

namespace Webgentle.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetLanguages();
    }
}