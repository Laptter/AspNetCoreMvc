using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository,
                              LanguageRepository languageRepository,
                              IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-detail/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public IEnumerable<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            var languages = await _languageRepository.GetLanguages();
            ViewBag.Language = new MultiSelectList(languages, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    var url = await UploadImage(folder, bookModel.CoverPhoto);
                    bookModel.CoverImageUrl = url;
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();
                    for (int i = 0; i < bookModel.GalleryFiles.Count; i++)
                    {
                        var url = await UploadImage(folder, bookModel.GalleryFiles[i]);
                        bookModel.Gallery.Add(new GalleryModel()
                        {
                            Name = bookModel.GalleryFiles[i].FileName,
                            URL = url,
                        });
                    }
                }

                if (bookModel.Pdf != null)
                {
                    string folder = "books/pdf/";
                    var url = await UploadImage(folder, bookModel.Pdf);
                    bookModel.PdfUrl = url;
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { IsSuccess = true, BookId = id });
                }
            }
            var languages = await _languageRepository.GetLanguages();
            ViewBag.Language = new MultiSelectList(languages, "Id", "Name");
            return View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<string> UploadImage(string folderPath, IFormFile formFile)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string serverFolder = System.IO.Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return $"/{folderPath}";
        }
    }
}