using System.Collections.Generic;

namespace Plumbium.Persistence.Repository
{
    public interface IRepository<TEntity, TIdentifier>
    {
        void Save(TEntity entity);

        void Delete(TIdentifier identifier);

        IEnumerable<TEntity> GetAll();
    }
}
