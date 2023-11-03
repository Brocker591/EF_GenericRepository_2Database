using EF_GenericRepository_2Database.Dtos;
using EF_GenericRepository_2Database_repository.Models;
using EF_GenericRepository_2Database_repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_GenericRepository_2Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Book> _bookRepository;

        public AuthorsController(IRepository<Author> authorRepository, IRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            try
            {
                var authors = await _authorRepository.GetAllAsync();
                var books = await _bookRepository.GetAllAsync();

                foreach (var author in authors)
                {
                    var booklist = books.Where(book => book.AuthorId == author.Id).ToList();
                    author.Books = booklist;
                }


                var authorDtos = authors.Select(x => new AuthorDto(x)).ToList();
                return authorDtos;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(long id)
        {
            try
            {
                var author = await _authorRepository.GetAsync(id);
                if (author is null)
                    return NotFound();

                var books = await _bookRepository.GetAllAsync();
                var booklist = books.Where(book => book.AuthorId == author.Id).ToList();
                author.Books = booklist;

                var authorDto = new AuthorDto(author);
                return authorDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(AuthorCreateDto dto)
        {
            try
            {
                var model = dto.ToModel();

                var createdModel = await _authorRepository.CreateAsync(model);

                var createdDto = new AuthorDto(createdModel);
                return createdDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update(AuthorUpdateDto dto)
        {
            try
            {
                var existingModel = await _authorRepository.GetAsync(dto.Id);
                if (existingModel is null)
                    return NotFound();

                existingModel.Firstname = dto.Firstname;
                existingModel.Lastname = dto.Lastname;
                existingModel.Age = dto.Age;

                await _authorRepository.UpdateAsync(existingModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var existingModel = await _authorRepository.GetAsync(id);
                if (existingModel is null)
                    return NotFound();

                await _authorRepository.RemoveAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
