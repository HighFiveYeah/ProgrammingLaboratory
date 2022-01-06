namespace ProgrammingLaboratory.PracowniaProgramowania.Data.DataTransferObjects;

public record struct InputCreateOrder(Guid ProductId, Guid UserId);

public record struct InputUpdateOrder(Guid Id, Guid ProductId, Guid UserId);

public record struct InputDeleteOrder(Guid Id);

public record struct InputGetOrder(Guid Id);

public record struct InputCreateProduct(string Name, decimal Price);

public record struct InputUpdateProduct(Guid Id, string Name, decimal Price);

public record struct InputDeleteProduct(Guid Id);

public record struct InputGetProduct(Guid Id);

public record struct InputCreateUser(string FirstName, string LastName, string Code, string Address);

public record struct InputUpdateUser(Guid Id, string FirstName, string LastName, string Code, string Address);

public record struct InputDeleteUser(Guid Id);

public record struct InputGetUser(Guid Id);