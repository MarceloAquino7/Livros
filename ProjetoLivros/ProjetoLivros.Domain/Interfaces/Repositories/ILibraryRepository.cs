using ProjetoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Domain.Interfaces.Repositories
{
    public interface ILibraryRepository : IRepositoryBase<Library>
    {
        IEnumerable<Library> GetAllOrderedByName();
    }
}
