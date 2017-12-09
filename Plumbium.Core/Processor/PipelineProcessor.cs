using Plumbium.Core.Interfaces.Repositories;
using Plumbium.Core.Models;
using System;
using System.Collections.Generic;

namespace Plumbium.Core.Processor
{
    public class PipelineProcessor : IPipelineProcessor
    {
        private readonly IRepository<Pipeline, Guid> _pipelineRepository;

        public PipelineProcessor(IRepository<Pipeline, Guid> pipelineRepository)
        {
            _pipelineRepository = pipelineRepository;
        }

        public Guid CreatePipeline(string pipelineName, int totalProgress)
        {
            Guid pipelineGuid = Guid.NewGuid();
            Pipeline Pipeline = new Pipeline()
            {
                Name = pipelineName,
                TotalProgress = totalProgress,
                CreationDate = DateTime.Now,
                Guid = pipelineGuid
            };

            _pipelineRepository.Save(Pipeline);

            return pipelineGuid;
        }

        public void UpdatePipeline(Guid pipelineGuid, int currentProgress)
        {
            Pipeline Pipeline = new Pipeline()
            {
                CurrentProgress = currentProgress,
            };

            _pipelineRepository.Update(pipelineGuid, Pipeline);
        }

        public void DeletePipeline(Guid pipelineGuid)
        {
            _pipelineRepository.Delete(pipelineGuid);
        }

        public IEnumerable<Pipeline> GetAllPipelines()
        {
            return _pipelineRepository.GetAll();
        }
    }
}
