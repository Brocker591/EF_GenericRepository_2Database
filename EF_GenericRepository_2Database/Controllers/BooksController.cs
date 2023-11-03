using EF_GenericRepository_2Database.Dtos;
using EF_GenericRepository_2Database.Dtos.EF_GenericRepository_2Database.Dtos;
using EF_GenericRepository_2Database_repository.Models;
using EF_GenericRepository_2Database_repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_GenericRepository_2Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            try
            {
                var books = await _repository.GetAllAsync();
                var booksDtos = books.Select(x => new BookDto(x)).ToList();
                return booksDtos;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(long id)
        {
            try
            {
                var book = await _repository.GetAsync(id);
                if (book is null)
                    return NotFound();

                var bookDto = new BookDto(book);
                return bookDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create(BookCreateDto dto)
        {
            try
            {
                var model = dto.ToModel();

                var createdModel = await _repository.CreateAsync(model);

                var createdDto = new BookDto(createdModel);
                return createdDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update(BookDto dto)
        {
            try
            {
                var existingModel = await _repository.GetAsync(dto.Id);
                if (existingModel is null)
                    return NotFound();

                existingModel.Title = dto.Title;
                existingModel.Publication = dto.Publication;
                existingModel.AuthorId = dto.AuthorId;

                await _repository.UpdateAsync(existingModel);

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
                var existingModel = await _repository.GetAsync(id);
                if (existingModel is null)
                    return NotFound();

                await _repository.RemoveAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
