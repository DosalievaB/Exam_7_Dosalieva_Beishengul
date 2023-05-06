using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название категории")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина названия категории должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описание не соответствует требованиям")]

        [StringLength(250, MinimumLength = 3, ErrorMessage = "Длина описания должна быть от 3 до 250 символов")]

        public string? Description { get; set; }
    }
}
