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
    public class BookAppService : AppServiceBase<Book>, IBookAppService
    {
        private readonly IBookService _bookService;

        public BookAppService(IBookService bookService)
            : base(bookService)
        {
            _bookService = bookService;
        }

        public List<Book> GetByName(string name)
        {
            return _bookService.GetByName(name);
        }

        public List<Book> GetAllOrderedByName()
        {
            return _bookService.GetAllOrderedByName();
        }
    }
}
