using LovelyReads.Core.Entities;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        if(author != null && author.IsDeleted != true )
        {
            if (request.Image != null)
            {
                var olderImagePath = author.Image;
                var imagePath = Path.Combine("AuthorStorage", request.Image!.FileName);

                if (!string.IsNullOrEmpty(olderImagePath) && File.Exists(olderImagePath))
                {
                    File.Delete(olderImagePath);
                }

                using Stream fileStream = new FileStream(imagePath, FileMode.Create);
                request.Image.CopyTo(fileStream);
                author.UpdateImage(imagePath);
            }


            author.Update(request.Born!,
                request.Died!,
                request.Description!,
                new Name(request.FullName!)); 

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            return Result.Fail(AuthorErrors.NotFound);      
        }

        return Result.Ok();
    }
}
