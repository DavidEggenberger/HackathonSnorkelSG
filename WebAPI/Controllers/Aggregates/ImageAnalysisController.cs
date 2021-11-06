using Domain.SnorkelAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        [HttpPost]
        public async Task<ActionResult<DetectResult>> AnalyzeImage(Image image)
        {
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(image.Base64Data));
            DetectResult detectResult = await ComputerVisionClient.DetectObjectsInStreamAsync(memoryStream);
            return Ok(detectResult);
        }
    }
}
