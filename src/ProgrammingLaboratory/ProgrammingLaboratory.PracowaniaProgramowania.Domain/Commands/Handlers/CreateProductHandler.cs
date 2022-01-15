using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<Product>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.Insert(new Product
        {
            Id = new Guid(),
            Deleted = false,
            DeletionDate = null,
            CreationDate = DateTimeOffset.Now,
            Name = request.Name,
            Price = request.Price
        });
        
        _unitOfWork.SaveChangesAsync();

        if (result.IsFailed)
            return result;
        
        return  Result.Ok(result.Value);
    }
}