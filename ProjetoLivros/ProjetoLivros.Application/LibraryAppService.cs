using ProjetoLivros.Application.Interfaces;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Application
{
    public class LibraryAppService : AppServiceBase<Library>, ILibraryAppService
    {
        private readonly ILibraryService _libraryService;

        public LibraryAppService(ILibraryService libraryService)
            : base(libraryService)
        {
            _libraryService = libraryService;
        }

        public List<Library> GetAllOrderedByName()
        {
            return _libraryService.GetAllOrderedByName();
        }
    }
}
