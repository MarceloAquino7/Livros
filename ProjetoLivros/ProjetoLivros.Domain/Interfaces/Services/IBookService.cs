using ProjetoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Domain.Interfaces.Services
{
    public interface IBookService : IServiceBase<Book>
    {
        List<Book> GetByName(string name);

        List<Book> GetAllOrderedByName();
    }
}
