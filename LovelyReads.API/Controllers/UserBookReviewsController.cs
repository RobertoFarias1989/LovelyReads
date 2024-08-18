using LovelyReads.Application.UserBookReview.Commands.CreateBookReview;
using LovelyReads.Application.UserBookReview.Commands.DeleteBookReview;
using LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;
using LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;
using LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/userbookreviews")]
    [ApiController]
    public class UserBookReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBookReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllBookReviewsQuery = new GetAllUserBookReviewsQuery();

            var bookReviews = await _mediator.Send(getAllBookReviewsQuery);

            return Ok(bookReviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getBookReviewByIdQuery = new GetUserBookReviewByIdQuery(id);

            var result = await _mediator.Send(getBookReviewByIdQuery);

            if (!result.Success) 
                return NotFound(result.Errors);           


            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserBookReviewCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(GetById), new { id = result .Value}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserBookReviewCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
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
