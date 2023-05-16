using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Webgentle.BookStore.Enums;

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
        public string Language { get; set; }
        [Required(ErrorMessage = "please select the language of the book")]
        public Language? LanguageEnum { get; set; }
        [Range(1, 10000)]
        [DisplayName("pages of book")]
        public int? TotalPages { get; set; }
    }
}
