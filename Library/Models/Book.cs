﻿using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Не указано название книги")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина названия книги должна быть от 3 до 50 символов")]
        public string ?Name { get; set; }
        [Required(ErrorMessage = "Не указан автор")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени автора должна быть от 3 до 50 символов")]
        public string Author { get; set; }
        [Required]
        public string Image { get; set; }
        public int YearIssue { get; set; }
        [Required(ErrorMessage = "Не указано описание")]

        [StringLength(350, MinimumLength = 3, ErrorMessage = "Длина описания книги должно быть от 3 до 350 символов")]
        public string ?Description { get; set; }
        [Required]
        public DateTime DateAdd { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
