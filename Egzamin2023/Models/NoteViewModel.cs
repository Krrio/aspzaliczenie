using System.ComponentModel.DataAnnotations;

namespace Egzamin2023.Models
{
    public class NoteViewModel
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć minimum 3 znaki")]
        public string Title { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Treść musi mieć minimum 10 znaków")]
        public string Content { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }
    }
}