using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.FirstName = request.FirstName;
        entityToUpdate.LastName = request.LastName;
        entityToUpdate.Code = request.Code;
        entityToUpdate.Address = request.Address;
        
        _unitOfWork.UserRepository.Update(entityToUpdate);
        
        _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}