using LovelyReads.Application.Genre.Commands.CreateGenre;
using LovelyReads.Application.Genre.Commands.DeleteGenre;
using LovelyReads.Application.Genre.Commands.UpdateGenre;
using LovelyReads.Application.Genre.Queries.GetAllGenre;
using LovelyReads.Application.Genre.Queries.GetGenreById;
using LovelyReads.Application.Genre.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    [Produces("application/json")]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de Genres")]
        [ProducesResponseType(typeof(List<GenreViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getAllGenreQuery = new GetAllGenresQuery();

            var genres = await _mediator.Send(getAllGenreQuery);

            return Ok(genres);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um Genre")]
        [ProducesResponseType(typeof(GenreDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var getGenreByIdQuery = new GetGenreByIdQuery(id);

            var result = await _mediator.Send(getGenreByIdQuery);

            if (!result.Success) 
                return NotFound(result.Errors);      

            return Ok(result.Value);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um Genre")]
        [ProducesResponseType(typeof(CreateGenreCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateGenreCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Value}, command);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um Genre")]
        [ProducesResponseType(typeof(UpdateGenreCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateGenreCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um Genre")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteGenreCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }
    }
}
