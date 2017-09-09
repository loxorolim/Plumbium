using Plumbium.Core.Models;
using System;
using System.Collections.Generic;

namespace Plumbium.Core.Processor
{
    public interface IPipelineProcessor
    {
        Guid CreatePipeline(string pipelineName);
        void DeletePipeline(Guid pipelineGuid);
        void UpdatePipeline(Guid pipelineGuid, int currentProgress);
        IEnumerable<PipelineModel> GetAllPipelines();
    }
}
