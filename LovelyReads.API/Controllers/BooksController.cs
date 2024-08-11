using LovelyReads.Application.Book.Commands.CreateBook;
using LovelyReads.Application.Book.Commands.DeleteBook;
using LovelyReads.Application.Book.Commands.UpdateBook;
using LovelyReads.Application.Book.Queries.GetAllBooks;
using LovelyReads.Application.Book.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllBooksQuery = new GetAllBooksQuery();

            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gGetBookByIdQuery = new GetBookByIdQuery(id);

            var book = await _mediator.Send(gGetBookByIdQuery);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();

        }

    }
}
