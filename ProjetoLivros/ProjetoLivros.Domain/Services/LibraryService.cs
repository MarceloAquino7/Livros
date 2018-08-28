using ProjetoLivros.Domain.Entities;
using ProjetoLivros.Domain.Interfaces.Repositories;
using ProjetoLivros.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Domain.Services
{
    public class LibraryService : ServiceBase<Library>, ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
            : base(libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public List<Library> GetAllOrderedByName()
        {
            return _libraryRepository.GetAllOrderedByName().ToList();
        }
    }
}
