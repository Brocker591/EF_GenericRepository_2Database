namespace EF_GenericRepository_2Database.Dtos
{
    using EF_GenericRepository_2Database_repository.Models;
    using System.ComponentModel.DataAnnotations;

    namespace EF_GenericRepository_2Database.Dtos
    {
        public class BookCreateDto
        {

            [Required]
            public string Title { get; set; }

            public int Publication { get; set; }
            [Required]
            public int AuthorId { get; set; }



            public BookCreateDto() { }

            public BookCreateDto(Book model)
            {
                Title = model.Title;
                Publication = model.Publication;
                AuthorId = model.AuthorId;
            }

            public Book ToModel()
            {
                return new Book
                {
                    Title = Title,
                    Publication = Publication,
                    AuthorId = AuthorId,
                };
            }
        }
    }

}
