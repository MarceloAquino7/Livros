using ProjetoLivros.Domain.Entities;
using ProjetoLivros.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivros.Infra.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public IEnumerable<Book> GetByName(string name)
        {
            return Db.Books.Where(b => b.Name.Contains(name));
        }

        public IEnumerable<Book> GetAllOrderedByName()
        {
            return Db.Books.OrderBy(b => b.Name);
        }
    }
}
