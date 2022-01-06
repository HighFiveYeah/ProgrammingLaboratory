using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries;

public record struct OrderQuery(Guid Id) : IRequest<Result<Order>>;

public record struct ProductQuery(Guid Id) : IRequest<Result<Product>>;

public record struct UserQuery(Guid Id) : IRequest<Result<User>>;