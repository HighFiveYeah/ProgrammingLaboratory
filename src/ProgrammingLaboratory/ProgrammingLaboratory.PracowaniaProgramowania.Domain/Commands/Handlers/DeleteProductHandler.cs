using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.Deleted = true;
        entityToUpdate.DeletionDate = DateTimeOffset.Now;

        _unitOfWork.ProductRepository.Update(entityToUpdate);
        
        _unitOfWork.SaveChangesAsync();
        
        return Result.Ok();
    }
}