using DAL.Models;

namespace DAL
{
    public class Database : IDatabase
    {
        private List<ValueEntity> _valueEntities;
        public Database()
        {
            _valueEntities = new List<ValueEntity>()
            {
                new ValueEntity
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Long description"
                },
                new ValueEntity
                {
                    Id = 2,
                    Name = "Name 2",
                    Description = "Long description"
                },
                new ValueEntity
                {
                    Id = 3,
                    Name = "Name 3",
                    Description = "Long description"
                },
                new ValueEntity
                {
                    Id = 4,
                    Name = "Name 4",
                    Description = "Long description"
                },
                new ValueEntity
                {
                    Id = 5,
                    Name = "Name 5",
                    Description = "Long description"
                },
                new ValueEntity
                {
                    Id = 6,
                    Name = "Name 6",
                    Description = "Long description"
                }
            };
        }

        public List<ValueEntity> ValueEntities { get; }

        public async Task<int> AddAsync(ValueEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                var last = _valueEntities.Last();
                entity.Id = last.Id + 1;
                _valueEntities.Add(entity);
            },
            cancellationToken);

            return entity.Id;
        }

        public async Task<List<ValueEntity>> FilterAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default)
        {
            var result = new List<ValueEntity>();

            await Task.Run(() => result = _valueEntities.Where(func).ToList(), cancellationToken);

            return result;
        }

        public async Task<IQueryable<ValueEntity>> QueryAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default)
        {
            var result = new List<ValueEntity>();

            await Task.Run(() => result = _valueEntities.Where(func).ToList(), cancellationToken);

            return result.AsQueryable();
        }

        public async Task<ValueEntity> FirstOrDedaultAsync(Func<ValueEntity, bool> func, CancellationToken cancellationToken = default)
        {
            var result = new ValueEntity();

            await Task.Run(() => result = _valueEntities.Where(func).FirstOrDefault(), cancellationToken);

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var entity = _valueEntities.FirstOrDefault(x => x.Id == id);
                _valueEntities.Remove(entity!);
            });
            return true;
        }
    }
}