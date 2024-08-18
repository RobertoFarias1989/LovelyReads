using LovelyReads.Application.Book.Commands.CreateBook;
using LovelyReads.Application.Book.Commands.DeleteBook;
using LovelyReads.Application.Book.Commands.UpdateBook;
using LovelyReads.Application.Book.Queries.GetAllBooks;
using LovelyReads.Application.Book.Queries.GetBookById;
using LovelyReads.Application.Book.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Produces("application/json")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de Books")]
        [ProducesResponseType(typeof(List<BookViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getAllBooksQuery = new GetAllBooksQuery();

            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um Book")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var gGetBookByIdQuery = new GetBookByIdQuery(id);

            var result = await _mediator.Send(gGetBookByIdQuery);

            if(!result.Success) 
                return NotFound(result.Errors);     

            return Ok(result.Value);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um Book")]
        [ProducesResponseType(typeof(CreateBookCommand),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromForm] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um Book")]
        [ProducesResponseType(typeof(UpdateBookCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um Book")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();

        }

    }
}
