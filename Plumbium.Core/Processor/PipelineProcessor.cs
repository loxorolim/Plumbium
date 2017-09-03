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
        private readonly IRepository<PipelineEntity> _pipelineRepository;

        public PipelineProcessor(IRepository<PipelineEntity> pipelineRepository)
        {
            _pipelineRepository = pipelineRepository;
        }

        public Guid CreatePipeline()
        {
            Guid pipelineGuid = Guid.NewGuid();
            PipelineEntity pipelineEntity = new PipelineEntity()
            {
                Name = "Teste",
                CreationDate = DateTime.Now,
                Guid = pipelineGuid
            };

            _pipelineRepository.Save(pipelineEntity);

            return pipelineGuid;
        }

        public IEnumerable<PipelineModel> GetAllPipelines()
        {
            IEnumerable<PipelineEntity> pipelineEntities = _pipelineRepository.GetAll();

            IEnumerable<PipelineModel> pipelineModels = Mapper.Map<IEnumerable<PipelineModel>>(pipelineEntities);

            return pipelineModels;
        }
    }
}
