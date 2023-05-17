namespace Webgentle.BookStore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public int TotalPages { get; set; }
        public string CoverImageUrl { get; set; }
        public ICollection<BookGallery> BookGalleries { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
