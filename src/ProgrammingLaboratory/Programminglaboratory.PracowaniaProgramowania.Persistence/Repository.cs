using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = applicationDbContext.Set<TEntity>();
    }

    public async Task<Result<TEntity>> Insert(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);

        return Result.Ok(result.Entity);
    }

    public async Task<Result<TEntity>> GetById(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
            return Result.Fail($"Entity of type: {typeof(TEntity)} with id: {id} can not be found");

        return Result.Ok(entity)!;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
    }
}