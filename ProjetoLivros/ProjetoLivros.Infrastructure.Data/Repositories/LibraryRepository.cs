using System.Collections.Generic;
using System.Linq;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.Domain.Interfaces.Repositories;

namespace ProjetoLivros.Infra.Data.Repositories
{
    public class LibraryRepository : RepositoryBase<Library>, ILibraryRepository
    {
        public IEnumerable<Library> GetAllOrderedByName()
        {
            return Db.Libraries.OrderBy(l => l.Name);
        }
    }
}
