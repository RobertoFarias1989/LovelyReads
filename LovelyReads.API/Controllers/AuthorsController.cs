using LovelyReads.Application.Author.Commands.CreateAuthor;
using LovelyReads.Application.Author.Commands.DeleteAuthor;
using LovelyReads.Application.Author.Commands.UpdateAuthor;
using LovelyReads.Application.Author.Queries.GetAllAuthors;
using LovelyReads.Application.Author.Queries.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllAuthorsQuery = new GetAllAuthorsQuery();

            var authors = await _mediator.Send(getAllAuthorsQuery);

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getAuthorByIdQuery = new GetAuthorByIdQuery(id);

            var author = await _mediator.Send(getAuthorByIdQuery);

            if (author == null) 
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateAuthorCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateAuthorCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
