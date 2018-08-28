using AutoMapper;
using ProjetoLivros.Application.Interfaces;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoLivros.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookAppService _bookApp;

        public BookController(IBookAppService bookApp)
        {
            _bookApp = bookApp;
        }

        [HttpGet]
        [Route("book/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("book/getall")]
        public ActionResult GetAll()
        {
            var bookViewModel = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(_bookApp.GetAll());
            return Json(bookViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("book/indexordered")]
        public ActionResult IndexOrdered()
        {
            var bookViewModel = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(_bookApp.GetAllOrderedByName());
            return Json(bookViewModel, JsonRequestBehavior.AllowGet);
        }

        // POST: Books/Create
        [HttpPost]
        [Route("book/create")]
        public ActionResult Create(BookViewModel book)
        {
            var bookDomain = Mapper.Map<BookViewModel, Book>(book);
            _bookApp.Add(bookDomain);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [Route("book/update")]
        public ActionResult Update(BookViewModel book)
        {
            var bookDomain = Mapper.Map<BookViewModel, Book>(book);
            _bookApp.Update(bookDomain);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [Route("book/delete")]
        public ActionResult Delete(BookViewModel book)
        {
            var bookToRemove = _bookApp.GetById(book.BookId);
            _bookApp.Remove(bookToRemove);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }
    }
}
