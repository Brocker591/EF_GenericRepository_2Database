using EF_GenericRepository_2Database_repository.Models;
using System.ComponentModel.DataAnnotations;

namespace EF_GenericRepository_2Database.Dtos
{
    public class AuthorCreateDto
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }

        public AuthorCreateDto() { }


        public AuthorCreateDto(Author model)
        {
            Firstname = model.Firstname;
            Lastname = model.Lastname;
            Age = model.Age;
        }

        public Author ToModel()
        {


            return new Author
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Age = Age,
            };
        }
    }
}
