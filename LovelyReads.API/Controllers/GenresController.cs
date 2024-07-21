using LovelyReads.Application.Genre.Commands.CreateGenre;
using LovelyReads.Application.Genre.Commands.DeleteGenre;
using LovelyReads.Application.Genre.Commands.UpdateGenre;
using LovelyReads.Application.Genre.Queries.GetAllGenre;
using LovelyReads.Application.Genre.Queries.GetGenreById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllGenreQuery = new GetAllGenreQuery();

            var genres = await _mediator.Send(getAllGenreQuery);

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getGenreByIdQuery = new GetGenreByIdQuery(id);

            var genre = await _mediator.Send(id);

            if (genre == null) 
            { 
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGenreCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateGenreCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteGenreCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
