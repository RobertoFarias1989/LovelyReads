﻿using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorDetailsViewModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        if(author == null) return null;

        var books = author.Books
            .Where(b => b.IdAuthor == author.Id)
            .Select(b => new BookViewModel(
                b.Id,
                b.Title,
                b.PublishedYear,
                b.AverageRating,
                b.BookCover)).ToList();

        var authorDetailsViewModel = new AuthorDetailsViewModel(
            author.Id,
            author.Born,
            author.Died,
            author.Description,
            author.Name.FullName,
            author.Image,
            books);

        return authorDetailsViewModel;
    }
}
