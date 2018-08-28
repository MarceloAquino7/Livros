using AutoMapper;
using ProjetoLivros.Application.Interfaces;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoLivros.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryAppService _libraryApp;

        public LibraryController(ILibraryAppService libraryApp)
        {
            _libraryApp = libraryApp;
        }

        [HttpGet]
        [Route("library/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("library/getall")]
        public ActionResult GetAll()
        {
            var libraryViewModel = Mapper.Map<IEnumerable<Library>, IEnumerable<LibraryViewModel>>(_libraryApp.GetAll());
            return Json(libraryViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("library/getorderedbyname")]
        public ActionResult IndexOrdered()
        {
            var libraryViewModel = Mapper.Map<IEnumerable<Library>, IEnumerable<LibraryViewModel>>(_libraryApp.GetAllOrderedByName());
            return Json(libraryViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("library/create")]
        public ActionResult Create(LibraryViewModel library)
        {
            var libraryDomain = Mapper.Map<LibraryViewModel, Library>(library);
            _libraryApp.Add(libraryDomain);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [Route("library/update")]
        public ActionResult Edit(LibraryViewModel library)
        {
            var libraryDomain = Mapper.Map<LibraryViewModel, Library>(library);
            _libraryApp.Update(libraryDomain);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [Route("library/delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var library = _libraryApp.GetById(id);
            _libraryApp.Remove(library);

            return Json("Success", JsonRequestBehavior.DenyGet);
        }
    }
}
