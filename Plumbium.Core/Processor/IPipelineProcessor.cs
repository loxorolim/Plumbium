using Plumbium.Domain.Models;
using System;
using System.Collections.Generic;

namespace Plumbium.Core.Processor
{
    public interface IPipelineProcessor
    {
        Guid CreatePipeline(string pipelineName, int totalProgress);
        void DeletePipeline(Guid pipelineGuid);
        void UpdatePipeline(Guid pipelineGuid, int currentProgress);
        IEnumerable<Pipeline> GetAllPipelines();
    }
}
