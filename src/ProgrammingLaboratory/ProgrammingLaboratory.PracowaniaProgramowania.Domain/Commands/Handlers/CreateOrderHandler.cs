using FluentResults;
using MediatR;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OrderRepository.Insert(new Order
        {
            Id = new Guid(),
            Deleted = false,
            DeletionDate = null,
            CreationDate = DateTimeOffset.Now,
            ProductId = request.ProductId,
            UserId = request.UserId,
            OrderDate = DateTimeOffset.Now
        });

        if (result.IsFailed)
            return result;
        
        return Result.Ok(result.Value);
    }
}