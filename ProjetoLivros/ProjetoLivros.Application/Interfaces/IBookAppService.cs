using ProjetoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivros.Application.Interfaces
{
    public interface IBookAppService : IAppServiceBase<Book>
    {
        List<Book> GetByName(string name);

        List<Book> GetAllOrderedByName();
    }
}
