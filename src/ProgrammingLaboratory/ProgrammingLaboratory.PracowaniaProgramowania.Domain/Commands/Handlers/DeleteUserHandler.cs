using FluentResults;
using MediatR;
using Programminglaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.Deleted = true;
        entityToUpdate.DeletionDate = DateTimeOffset.Now;

        _unitOfWork.UserRepository.Update(entityToUpdate);
        
        _unitOfWork.SaveChangesAsync();
        
        return Result.Ok();
    }
}