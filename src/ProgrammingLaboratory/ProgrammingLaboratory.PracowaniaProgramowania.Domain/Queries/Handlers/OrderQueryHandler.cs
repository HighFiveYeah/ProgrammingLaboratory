using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries.Handlers;

public class OrderQueryHandler : IRequestHandler<OrderQuery, Result<Order>>
{
    private readonly IRepository<Order> _repository;

    public OrderQueryHandler(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Order>> Handle(OrderQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);

        if (result.IsFailed)
            return result;
        
        return Result.Ok(result.Value);
    }
}