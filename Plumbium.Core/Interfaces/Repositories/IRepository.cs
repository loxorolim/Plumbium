using System.Collections.Generic;

namespace Plumbium.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity, TIdentifier>
    {
        void Save(TEntity entity);

        void Delete(TIdentifier identifier);

        void Update(TIdentifier identifier, TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
