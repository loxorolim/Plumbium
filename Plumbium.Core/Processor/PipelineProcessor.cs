using AutoMapper;
using Plumbium.Core.Models;
using Plumbium.Persistence.Entities;
using Plumbium.Persistence.Repository;
using System;
using System.Collections.Generic;

namespace Plumbium.Core.Processor
{
    public class PipelineProcessor : IPipelineProcessor
    {
        private readonly IRepository<PipelineEntity, Guid> _pipelineRepository;
        private readonly IMapper _autoMapper;

        public PipelineProcessor(IRepository<PipelineEntity, Guid> pipelineRepository)
        {
            _pipelineRepository = pipelineRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PipelineEntity, PipelineModel>());

            _autoMapper = config.CreateMapper();

        }

        public Guid CreatePipeline(string pipelineName, int totalProgress)
        {
            Guid pipelineGuid = Guid.NewGuid();
            PipelineEntity pipelineEntity = new PipelineEntity()
            {
                Name = pipelineName,
                TotalProgress = totalProgress,
                CreationDate = DateTime.Now,
                Guid = pipelineGuid
            };

            _pipelineRepository.Save(pipelineEntity);

            return pipelineGuid;
        }

        public void UpdatePipeline(Guid pipelineGuid, int currentProgress)
        {
            PipelineEntity pipelineEntity = new PipelineEntity()
            {
                CurrentProgress = currentProgress,
            };

            _pipelineRepository.Update(pipelineGuid, pipelineEntity);
        }

        public void DeletePipeline(Guid pipelineGuid)
        {
            _pipelineRepository.Delete(pipelineGuid);
        }

        public IEnumerable<PipelineModel> GetAllPipelines()
        {
            IEnumerable<PipelineEntity> pipelineEntities = _pipelineRepository.GetAll();

            IEnumerable<PipelineModel> pipelineModels = _autoMapper.Map<IEnumerable<PipelineModel>>(pipelineEntities);

            return pipelineModels;
        }
    }
}
