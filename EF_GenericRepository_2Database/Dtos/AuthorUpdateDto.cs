using EF_GenericRepository_2Database_repository.Models;
using System.ComponentModel.DataAnnotations;

namespace EF_GenericRepository_2Database.Dtos
{
    public class AuthorUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Age { get; set; }

    }
}
