namespace Webgentle.BookStore.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsLoggedIn();
    }
}