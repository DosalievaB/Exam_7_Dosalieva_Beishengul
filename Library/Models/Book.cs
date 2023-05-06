using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public Book() { }
        public Book(string? name, string author, string image, int yearissue, string? description, DateTime dateAdd, int categoryId)
        {
            Name = name;
            Author = author;
            Image = image;
            YearIssue = yearissue; 
            Description = description;
            DateAdd = dateAdd;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 50 символов")]
        public string ?Name { get; set; }
        public string Author { get; set; }
        [Required]
        public string Image { get; set; }
        public int YearIssue { get; set; } 
        public string ?Description { get; set; }
        public DateTime DateAdd { get; set; }
        public int? CategoryId { get; set; }
    }
}
