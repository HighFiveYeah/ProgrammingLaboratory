using Microsoft.EntityFrameworkCore;
using ProgrammingLaboratory.PracowniaProgramowania.Data.Entities;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}