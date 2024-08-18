using LovelyReads.Application.User.Commands.CreateUser;
using LovelyReads.Application.User.Commands.DeleteUser;
using LovelyReads.Application.User.Commands.UpdateUser;
using LovelyReads.Application.User.Queries.GetAllUsers;
using LovelyReads.Application.User.Queries.GetUserById;
using LovelyReads.Application.User.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LovelyReads.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de Users")]
        [ProducesResponseType(typeof(List<UserViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var getAllUsersQuery = new GetAllUsersQuery();

            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um User")]
        [ProducesResponseType(typeof(UserDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);

            var result = await _mediator.Send(getUserByIdQuery);

            if (!result.Success)
                return NotFound(result.Errors);

            return Ok(result.Value);

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um User")]
        [ProducesResponseType(typeof(CreateUserCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um User")]
        [ProducesResponseType(typeof(UpdateUserCommand), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Errors);

            return NoContent();
        }
    }
}
