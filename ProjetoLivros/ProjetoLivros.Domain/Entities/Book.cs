using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivros.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string PublisherName { get; set; }
        public double Price { get; set; }
    }
}