using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        [Remote(action: "CheckName", controller: "Validation", ErrorMessage = "Это имя пользователя уже занято")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано фамилия")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина фамилии должна быть от 3 до 50 символов")]
        public string Surname { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
