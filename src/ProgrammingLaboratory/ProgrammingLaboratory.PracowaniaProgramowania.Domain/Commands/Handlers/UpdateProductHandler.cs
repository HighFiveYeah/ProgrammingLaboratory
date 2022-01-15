using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.GetById(request.Id);

        if (result.IsFailed)
            return result.ToResult();

        var entityToUpdate = result.Value;

        entityToUpdate.Name = request.Name;
        entityToUpdate.Price = request.Price;

        _unitOfWork.ProductRepository.Update(entityToUpdate);

        _unitOfWork.SaveChangesAsync();
        
        return Result.Ok();
    }
}