﻿using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.Author.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        //contruir o objeto que irá ser salvo no banco
        //você vai receber os parâmetros e passar para a entidade;

        var imagePath = Path.Combine("AuthorStorage", request.Image!.FileName);

        //Quando for rodar os testes unitários comente as linhas abaixo referentes a criação e cópia da imagem
        using Stream fileStream = new FileStream(imagePath, FileMode.Create);

        request.Image.CopyTo(fileStream);

        var author = new Core.Entities.Author(
            request.Born!,
            request.Died!,
            request.Description!,
            new Name(request.FullName!),
            imagePath);

        await _unitOfWork.AuthorRepository.AddAsync(author);

        await _unitOfWork.CompleteAsync();

        return Result.Ok(author.Id);

    }
}
