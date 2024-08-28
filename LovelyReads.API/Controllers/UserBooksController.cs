using LovelyReads.Application.UserBook.Commads.CreateUserBook;
using LovelyReads.Application.UserBook.Commads.DeleteUserBook;
using LovelyReads.Application.UserBook.Commads.FinishUserBook;
using LovelyReads.Application.UserBook.Commads.UpdateUserBook;
using LovelyReads.Application.UserBook.Queries.GetAllUserBook;
using LovelyReads.Application.UserBook.Queries.GetUserBookById;
using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/userbooks")]
    [ApiController]
    [Produces("application/json")]
    public class UserBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de livros lidos ou não pelo usuário")]
        [ProducesResponseType(typeof(List<UserBookDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(DateTime? startToReadAt, DateTime? finishReadAt)
        {
            var getAllUserBooksQuery = new GetAllUserBooksQuery(startToReadAt, finishReadAt);

            var userBooks = await _mediator.Send(getAllUserBooksQuery);

            return Ok(userBooks);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um livro específico")]
        [ProducesResponseType(typeof(UserBookDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var getUserBookByIdQuery = new GetUserBookByIdQuery(id);

            var result = await _mediator.Send(getUserBookByIdQuery);

            if(!result.Success)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Inicia a leitura de um livro pelo usuário")]
        [ProducesResponseType(typeof(CreateUserBookCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateUserBookCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
        }

        [HttpPut("updatepageamountreaded/{id}")]
        [SwaggerOperation(Summary = "Atualiza a quantidade de páginas lidas de um livro")]
        [ProducesResponseType(typeof(UpdateUserBookCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePageAmountReaded(int id, UpdateUserBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpPut("finishread/{id}")]
        [SwaggerOperation(Summary = "Encerra a leitura de um livro")]
        [ProducesResponseType(typeof(FinishUserBookCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FinishRead(int id, FinishUserBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta logicamente um  livro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUserBookCommand = new DeleteUserBookCommand(id);

            var result = await _mediator.Send(deleteUserBookCommand);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();

        }
    }
}
