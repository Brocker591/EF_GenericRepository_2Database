using EF_GenericRepository_2Database_repository.Models;
using System.ComponentModel.DataAnnotations;

namespace EF_GenericRepository_2Database.Dtos
{
    public class BookDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public int Publication { get; set; }
        [Required]
        public int AuthorId { get; set; }



        public BookDto() { }

        public BookDto(Book model) 
        {
            Id = model.Id;
            Title = model.Title;
            Publication = model.Publication;
            AuthorId = model.AuthorId;
        }

        public Book ToModel()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Publication = Publication,
                AuthorId = AuthorId,
            };
        }
    }
}
