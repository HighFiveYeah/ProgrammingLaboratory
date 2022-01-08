using FluentResults;
using MediatR;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.Insert(new User
        {
            Id = new Guid(),
            Deleted = false,
            DeletionDate = null,
            CreationDate = DateTimeOffset.Now,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Code = request.Code,
            Address = request.Address
        });
        
        _unitOfWork.SaveChangesAsync();

        if (result.IsFailed)
            return result;
        
        return Result.Ok(result.Value);
    }
}