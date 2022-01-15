using FluentResults;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Persistence; 
public interface IRepository<TEntity> where TEntity : class
{
    public Task<Result<TEntity>> Insert(TEntity entity);
    public Task<Result<TEntity>> GetById(Guid id);
    public void Update(TEntity entity);
}