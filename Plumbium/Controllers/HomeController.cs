using Microsoft.AspNetCore.Mvc;
using Plumbium.Core.Processor;
using Plumbium.Domain.Models;
using Plumbium.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Plumbium.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPipelineProcessor _pipelineProcessor;

        public HomeController(IPipelineProcessor pipelineProcesor)
        {
            _pipelineProcessor = pipelineProcesor;
        }

        public IActionResult Index()
        {
            IEnumerable<Pipeline> pipelines = _pipelineProcessor.GetAllPipelines();

            return View(pipelines);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
