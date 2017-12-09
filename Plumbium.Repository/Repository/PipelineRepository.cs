using MongoDB.Driver;
using Plumbium.Core.Interfaces.Repositories;
using Plumbium.Core.Models;
using System;
using System.Collections.Generic;

namespace Plumbium.Persistence.Repository
{
    public class PipelineRepository : IRepository<Pipeline, Guid>
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Pipeline> _pipelineCollection;

        public PipelineRepository()
        {
            var client = new MongoClient();
            _database = client.GetDatabase("Teste");
            _pipelineCollection = _database.GetCollection<Pipeline>("PipelineCollection");
        }

        public void Delete(Guid identifier)
        {
            FilterDefinition<Pipeline> filter = Builders<Pipeline>.Filter.Eq("Guid", identifier);

            _pipelineCollection.DeleteOne(filter);
        }

        public void Update(Guid identifier, Pipeline newEntity)
        {
            FilterDefinition<Pipeline> filter = Builders<Pipeline>.Filter.Eq("Guid", identifier);
            UpdateDefinition<Pipeline> update = Builders<Pipeline>.Update.Set("CurrentProgress", newEntity.CurrentProgress);

            _pipelineCollection.UpdateOne(filter, update);
        }

        public IEnumerable<Pipeline> GetAll()
        {
            return _pipelineCollection.Find(x => true).ToList();
        }

        public void Save(Pipeline entity)
        {
            _pipelineCollection.InsertOne(entity);
        }

    }
}
