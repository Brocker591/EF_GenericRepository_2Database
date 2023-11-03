using EF_GenericRepository_2Database_repository.Models;
using System.ComponentModel.DataAnnotations;

namespace EF_GenericRepository_2Database.Dtos
{
    public class AuthorDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public int Age { get; set; }
        public List<BookDto> Books { get; set; }

        public AuthorDto() { }


        public AuthorDto(Author model)
        {
            Id = model.Id;
            Firstname = model.Firstname;
            Lastname = model.Lastname;
            Age = model.Age;

            if (model.Books == null)
                Books = new List<BookDto>();
            else
                Books = model.Books.Select(x => new BookDto(x)).ToList();
        }

        public Author ToModel()
        {
            Author author = new Author();

            author.Id = Id;
            author.Firstname = Firstname;
            author.Lastname = Lastname;
            author.Age = Age;

            if (Books == null)
                author.Books = new List<Book>();
            else
                author.Books = Books.Select(x => x.ToModel()).ToList();


            return author;
        }
    }
}
