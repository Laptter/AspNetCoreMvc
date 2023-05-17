using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "please enter the title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "please enter the author of the book")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]
        public int? LanguageID { get; set; }
        public string Language { get; set; }
        [Range(1, 10000)]
        [DisplayName("pages of book")]
        public int? TotalPages { get; set; }
        public string CoverImageUrl { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
    }
}
