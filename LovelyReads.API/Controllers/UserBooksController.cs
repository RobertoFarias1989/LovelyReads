﻿using LovelyReads.Application.UserBook.Commads.CreateUserBook;
using LovelyReads.Application.UserBook.Commads.DeleteUserBook;
using LovelyReads.Application.UserBook.Commads.FinishUserBook;
using LovelyReads.Application.UserBook.Commads.UpdateUserBook;
using LovelyReads.Application.UserBook.Queries.GetAllUserBook;
using LovelyReads.Application.UserBook.Queries.GetUserBookById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LovelyReads.API.Controllers
{
    [Route("api/userbooks")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllUserBooksQuery = new GetAllUserBooksQuery();

            var userBooks = await _mediator.Send(getAllUserBooksQuery);

            return Ok(userBooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getUserBookByIdQuery = new GetUserBookByIdQuery(id);

            var userBook = await _mediator.Send(getUserBookByIdQuery);

            if(userBook == null)
            {
                return NotFound();
            }

            return Ok(userBook);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("updatepageamountreaded/{id}")]
        public async Task<IActionResult> UpdatePageAmountReaded(int id, UpdateUserBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("finishread/{id}")]
        public async Task<IActionResult> FinishRead(int id, FinishUserBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUserBookCommand = new DeleteUserBookCommand(id);

            await _mediator.Send(deleteUserBookCommand);

            return NoContent();

        }
    }
}
