using System.Collections.Generic;

namespace Plumbium.Persistence.Repository
{
    public interface IRepository<TEntity>
    {
        void Save(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
