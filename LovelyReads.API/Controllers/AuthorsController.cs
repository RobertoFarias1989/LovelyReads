using LovelyReads.Application.Author.Commands.CreateAuthor;
using LovelyReads.Application.Author.Commands.DeleteAuthor;
using LovelyReads.Application.Author.Commands.UpdateAuthor;
using LovelyReads.Application.Author.Queries.GetAllAuthors;
using LovelyReads.Application.Author.Queries.GetAuthorById;
using LovelyReads.Application.Author.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/authors")] 
    [ApiController]
    [Produces("application/json")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Obtém a lista de Authors")]
        [ProducesResponseType(typeof(List<AuthorViewModel>),StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getAllAuthorsQuery = new GetAllAuthorsQuery();

            var authors = await _mediator.Send(getAllAuthorsQuery);

            return Ok(authors);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Obtém um Author")]
        [ProducesResponseType(typeof(AuthorDetailsViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var getAuthorByIdQuery = new GetAuthorByIdQuery(id);

            var result = await _mediator.Send(getAuthorByIdQuery);

            if (!result.Success)     
                return NotFound(result.Errors);
      

            return Ok(result.Value);
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        [SwaggerOperation(Summary = "Adiciona um Author")]
        [ProducesResponseType(typeof(CreateAuthorCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "manager")]
        [SwaggerOperation(Summary = "Atualiza um Author")]
        [ProducesResponseType(typeof(UpdateAuthorCommand),StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateAuthorCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        [SwaggerOperation(Summary = "Deleta um Author")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
