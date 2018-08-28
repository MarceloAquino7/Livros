using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivros.Domain.Entities
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}