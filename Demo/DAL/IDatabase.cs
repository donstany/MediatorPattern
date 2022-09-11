using DAL.Models;

public interface IDatabase
{
    List<ValueEntity> ValueEntities { get; }

    Task<int> AddAsync(ValueEntity entity, CancellationToken cancellationToken = default);

    Task<List<ValueEntity>> FilterAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default);

    Task<IQueryable<ValueEntity>> QueryAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default);

    Task<ValueEntity> FirstOrDedaultAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id);
}