using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OrderRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.ProductId = request.ProductId;
        entityToUpdate.UserId = request.UserId;

        _unitOfWork.OrderRepository.Update(entityToUpdate);
        
        _unitOfWork.SaveChangesAsync();
        
        return Result.Ok();
    }
}