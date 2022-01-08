using FluentResults;
using MediatR;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OrderRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.Deleted = true;
        entityToUpdate.DeletionDate = DateTimeOffset.Now;

        _unitOfWork.OrderRepository.Update(entityToUpdate);
        
        _unitOfWork.SaveChangesAsync();
        
        return Result.Ok();
    }
}