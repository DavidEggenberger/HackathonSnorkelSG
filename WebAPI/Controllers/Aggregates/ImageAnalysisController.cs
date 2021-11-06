using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAnalysisController : ControllerBase
    {
        private ComputerVisionClient ComputerVisionClient { get; }
        public ImageAnalysisController(ComputerVisionClient computerVisionClient)
        {
            ComputerVisionClient = computerVisionClient;
        }
        
        public async Task<ActionResult> AnalyzeImage()
        {
            await ComputerVisionClient.DetectObjectsInStreamAsync();
        }
    }
}
