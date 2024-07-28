using LovelyReads.Application.BookReview.Commands.CreateBookReview;
using LovelyReads.Application.BookReview.Commands.DeleteBookReview;
using LovelyReads.Application.BookReview.Commands.UpdateBookReview;
using LovelyReads.Application.BookReview.Queries.GetAllBookReviews;
using LovelyReads.Application.BookReview.Queries.GetBookReviewById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllBookReviewsQuery = new GetAllBookReviewsQuery();

            var bookReviews = await _mediator.Send(getAllBookReviewsQuery);

            return Ok(bookReviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getBookReviewByIdQuery = new GetBookReviewByIdQuery(id);

            var bookReview = await _mediator.Send(getBookReviewByIdQuery);

            if (bookReview == null) 
            { 
                return NotFound();            
            }

            return Ok(bookReview);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookReviewCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBookReviewCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookReviewCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
