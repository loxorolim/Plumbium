using Microsoft.AspNetCore.Mvc;
using Plumbium.Api.Contracts;
using Plumbium.Core.Processor;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Plumbium.Api.Controllers
{
    [Route("api/[controller]")]
    public class PipelinesController : Controller
    {
        private readonly IPipelineProcessor _pipelineProcessor;

        public PipelinesController(IPipelineProcessor pipelineProcesor)
        {
            _pipelineProcessor = pipelineProcesor;
        }

        // GET: api/pipelines
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pipelines/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pipelines
        [HttpPost]
        public CreatePipelineResponse Post([FromBody] CreatePipelineContract createPipelineContract)
        {
            Guid pipelineIdentifier = _pipelineProcessor.CreatePipeline(createPipelineContract.Name);

            return new CreatePipelineResponse()
            {
                Identifier = pipelineIdentifier
            };
        }

        // PUT api/pipelines/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pipelines/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _pipelineProcessor.DeletePipeline(id);
        }
    }
}
