using System.ComponentModel.DataAnnotations;

namespace ProjetoLivros.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "field Name required")]
        [MaxLength(150, ErrorMessage = "Max {0} characters")]
        [MinLength(2, ErrorMessage = "Min {0} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "field Author required ")]
        [MaxLength(150, ErrorMessage = "Max {0} characters")]
        [MinLength(2, ErrorMessage = "Min {0} characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "field Publisher required")]
        [MaxLength(100, ErrorMessage = "Max {0} characters")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "field Price required")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}