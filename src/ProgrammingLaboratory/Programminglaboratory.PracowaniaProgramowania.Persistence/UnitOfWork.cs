using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace Programminglaboratory.PracowaniaProgramowania.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public IRepository<User> UserRepository { get; }
    public IRepository<Product> ProductRepository { get; }
    public IRepository<Order> OrderRepository { get; }

    public UnitOfWork(ApplicationDbContext dbContext, IRepository<User> userRepository, IRepository<Product> productRepository, IRepository<Order> orderRepository)
    {
        UserRepository = userRepository;
        ProductRepository = productRepository;
        OrderRepository = orderRepository;
        
        _dbContext = dbContext;
    }
    
    public void SaveChangesAsync() => _dbContext.SaveChangesAsync();
}