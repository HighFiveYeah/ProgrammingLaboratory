using FluentResults;
using MediatR;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries.Handlers;

public class UserQueryHandler : IRequestHandler<UserQuery, Result<User>>
{
    private readonly IRepository<User> _repository;

    public UserQueryHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<User>> Handle(UserQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);

        if (result.IsFailed)
            return result;
        
        return Result.Ok(result.Value);
    }
}