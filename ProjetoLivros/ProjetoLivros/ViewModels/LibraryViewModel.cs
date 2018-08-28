using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivros.ViewModels
{
    public class LibraryViewModel
    {
        [Key]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "field Name required")]
        [MaxLength(150, ErrorMessage = "Max {0} characters")]
        [MinLength(2, ErrorMessage = "Min {0} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "field Address required")]
        [MaxLength(150, ErrorMessage = "Max {0} characters")]
        [MinLength(2, ErrorMessage = "Min {0} characters")]
        public decimal Address { get; set; }
    }
}