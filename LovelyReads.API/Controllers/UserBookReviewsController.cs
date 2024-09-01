using LovelyReads.Application.UserBookReview.Commands.CreateBookReview;
using LovelyReads.Application.UserBookReview.Commands.DeleteBookReview;
using LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;
using LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;
using LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;
using LovelyReads.Application.UserBookReview.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/userbookreviews")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class UserBookReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBookReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Obtém a lista de avaliações dos livros lidos pelo usuário")]
        [ProducesResponseType(typeof(List<UserBookReviewViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getAllBookReviewsQuery = new GetAllUserBookReviewsQuery();

            var bookReviews = await _mediator.Send(getAllBookReviewsQuery);

            return Ok(bookReviews);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Obtém um UserBookReview/Obtém uma avaliação específica")]
        [ProducesResponseType(typeof(UserBookReviewDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var getBookReviewByIdQuery = new GetUserBookReviewByIdQuery(id);

            var result = await _mediator.Send(getBookReviewByIdQuery);

            if (!result.Success) 
                return NotFound(result.Errors);           


            return Ok(result.Value);
        }

        [HttpPost]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Adiciona uma avaliação a um livro")]
        [ProducesResponseType(typeof(CreateUserBookReviewCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateUserBookReviewCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(GetById), new { id = result .Value}, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Atualiza uma avaliação de um livro")]
        [ProducesResponseType(typeof(UpdateUserBookReviewCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateUserBookReviewCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager, reader")]
        [SwaggerOperation(Summary = "Deleta uma avaliação de um livro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserBookReviewCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }
    }
}
