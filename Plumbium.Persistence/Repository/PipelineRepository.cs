using MongoDB.Driver;
using Plumbium.Persistence.Entities;
using System.Collections.Generic;

namespace Plumbium.Persistence.Repository
{
    public class PipelineRepository : IRepository<PipelineEntity>
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<PipelineEntity> _pipelineCollection;

        public PipelineRepository()
        {
            var client = new MongoClient();
            _database = client.GetDatabase("Teste");
            _pipelineCollection = _database.GetCollection<PipelineEntity>("PipelineCollection");
        }

        public IEnumerable<PipelineEntity> GetAll()
        {
            return _pipelineCollection.Find(x => true).ToList();
        }

        public void Save(PipelineEntity entity)
        {
            _pipelineCollection.InsertOne(entity);
        }
    }
}
