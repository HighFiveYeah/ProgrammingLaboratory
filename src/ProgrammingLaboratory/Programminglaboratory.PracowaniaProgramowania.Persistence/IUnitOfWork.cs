using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Persistence;

public interface IUnitOfWork
{
    public void SaveChangesAsync();
    public IRepository<User> UserRepository { get; }
    public IRepository<Order> OrderRepository { get; }
    public IRepository<Product> ProductRepository { get; }
}