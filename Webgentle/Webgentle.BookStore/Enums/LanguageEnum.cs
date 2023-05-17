using System.ComponentModel.DataAnnotations;

namespace Webgentle.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Hindi Language")]
        Hindi = 10,
        [Display(Name = "English Language")]
        English,
        [Display(Name = "German Language")]
        German,
        [Display(Name = "Chinese Language")]
        Chinese,
        [Display(Name = "Urdu Language")]
        Urdu
    }
}
