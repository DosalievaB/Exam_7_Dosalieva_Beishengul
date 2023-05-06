using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описание не соответствует требованиям")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина описания должна быть от 3 до 50 символов")]

        public string? Description { get; set; }
    }
}
