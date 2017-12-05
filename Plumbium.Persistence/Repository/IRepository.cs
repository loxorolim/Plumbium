using System.Collections.Generic;

namespace Plumbium.Persistence.Repository
{
    public interface IRepository<TEntity, TIdentifier>
    {
        void Save(TEntity entity);

        void Delete(TIdentifier identifier);

        void Update(TIdentifier identifier, TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
