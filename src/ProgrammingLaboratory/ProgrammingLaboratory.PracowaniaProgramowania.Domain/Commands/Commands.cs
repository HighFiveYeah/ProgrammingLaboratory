using FluentResults;
using MediatR;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands;

public record struct CreateOrderCommand(Guid ProductId, Guid UserId) : IRequest<Result<Order>>;

public record struct UpdateOrderCommand(Guid Id, Guid ProductId, Guid UserId) : IRequest<Result>;

public record struct DeleteOrderCommand(Guid Id) : IRequest<Result>;

public record struct CreateProductCommand(string Name, decimal Price) : IRequest<Result<Product>>;

public record struct UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<Result>;

public record struct DeleteProductCommand(Guid Id) : IRequest<Result>;

public record struct CreateUserCommand(string FirstName, string LastName, string Code, string Address) : IRequest<Result<User>>;

public record struct UpdateUserCommand(Guid Id, string FirstName, string LastName, string Code, string Address) : IRequest<Result>;

public record struct DeleteUserCommand(Guid Id) : IRequest<Result>;