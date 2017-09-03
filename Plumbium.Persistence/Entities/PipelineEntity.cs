using MongoDB.Bson;
using System;

namespace Plumbium.Persistence.Entities
{
    public class PipelineEntity
    {
        public ObjectId Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
