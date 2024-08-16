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
    [Route("api/authors")]
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

            var result = await _mediator.Send(getAuthorByIdQuery);

            if (!result.Success)     
                return NotFound(result.Errors);
      

            return Ok(result.Value);
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
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }
    }
}
