using System;

namespace Plumbium.Core.Models
{
    public class PipelineModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalProgress { get; set; }
        public int CurrentProgress { get; set; }
    }
}
