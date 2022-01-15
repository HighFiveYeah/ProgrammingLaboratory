using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries.Handlers;

public class ProductQueryHandler : IRequestHandler<ProductQuery, Result<Product>>
{
    private readonly IRepository<Product> _repository;

    public ProductQueryHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Product>> Handle(ProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);

        if (result.IsFailed)
            return result;
        
        return Result.Ok(result.Value);
    }
}