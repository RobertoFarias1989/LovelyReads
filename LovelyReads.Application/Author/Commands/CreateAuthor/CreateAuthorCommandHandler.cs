﻿using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.Author.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        //contruir o objeto que irá ser salvo no banco
        //você vai receber os parâmetros e passar para a entidade;

        var author = new Core.Entities.Author(
            request.Born,
            request.Died,
            request.Description,
            new Name(request.FullName),
            request.Image);

        await _unitOfWork.AuthorRepository.AddAsync(author);

        await _unitOfWork.CompleteAsync();

        return author.Id;

    }
}
