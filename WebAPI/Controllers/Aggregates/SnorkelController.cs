using Domain;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnorkelController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext { get; }
        public SnorkelController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snorkel>>> GetSnorkels()
        {
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateSnorkel()
        {

        }
    }
}
