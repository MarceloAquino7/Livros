using ProjetoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IEnumerable<Book> GetByName(string name);

        IEnumerable<Book> GetAllOrderedByName();
    }
}
