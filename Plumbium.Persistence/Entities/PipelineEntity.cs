using MongoDB.Bson;
using System;

namespace Plumbium.Persistence.Entities
{
    public class PipelineEntity
    {
        public ObjectId Id { get; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalProgress { get; set; }
        public int CurrentProgress { get; set; }

    }
}
