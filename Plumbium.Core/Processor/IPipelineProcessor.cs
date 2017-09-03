using Plumbium.Core.Models;
using System;
using System.Collections.Generic;

namespace Plumbium.Core.Processor
{
    public interface IPipelineProcessor
    {
        Guid CreatePipeline();
        IEnumerable<PipelineModel> GetAllPipelines();
    }
}
