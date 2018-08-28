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
    public class BookService : ServiceBase<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
            : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetByName(string name)
        {
            return _bookRepository.GetByName(name).ToList();
        }

        public List<Book> GetAllOrderedByName()
        {
            return _bookRepository.GetAllOrderedByName().ToList();
        }
    }
}
