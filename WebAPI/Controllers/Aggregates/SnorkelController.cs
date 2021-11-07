using Domain;
using Domain.ApplicationUserAggregate;
using Domain.SnorkelAggregate;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnorkelController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext { get; }
        private UserManager<ApplicationUser> userManager { get; }
        public SnorkelController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snorkel>>> GetSnorkels()
        {
            return Ok(applicationDbContext.Snorkels
                .Include(s => s.Image).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Snorkel>> GetSnorkelById(Guid id)
        {
            return Ok(applicationDbContext.Snorkels
                .Include(snorkel => snorkel.Image)
                .Include(snorkel => snorkel.SnorkelSupports)
                .Include(snorkel => snorkel.ActivityInfos)
                .Include(snorkel => snorkel.DescriptionInfos)
                .Include(snorkel => snorkel.HistoryInfos)
                .FirstOrDefault(snorkel => snorkel.Id == id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Snorkel>> DeleteSnorkelById(Guid id)
        {
            ApplicationUser applicationUser = await userManager.FindByIdAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Snorkel snorkel = applicationDbContext.Snorkels.Find(id);
            if(snorkel.ApplicationUserId == applicationUser.Id)
            {
                applicationDbContext.Remove(snorkel);
                await applicationDbContext.SaveChangesAsync();
            }  
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateSnorkel(Snorkel snorkel, [FromServices] IWebHostEnvironment env)
        {
            ApplicationUser applicationUser = await userManager.FindByIdAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Guid createdId = Guid.NewGuid();
            snorkel.Id = createdId;
            snorkel.ApplicationUserId = applicationUser.Id;
            //Guid pictureUri = Guid.NewGuid();
            //using FileStream fs = System.IO.File.Create(env.WebRootPath + "/" + pictureUri + ".jpg");
            //await fs.WriteAsync(Convert.FromBase64String(snorkel.Image.Base64Data));
            //snorkel.Image.ImageAddress = env.WebRootPath + "/" + pictureUri + ".jpg";
            //snorkel.Image.Base64Data = string.Empty;
            applicationDbContext.Snorkels.Add(snorkel);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("{id}")]
        [Authorize]
        public async Task<ActionResult> SupportSnorkel([FromRoute] Guid id, [FromBody] SnorkelSupport snorkelSupport)
        {
            ApplicationUser applicationUser = await userManager.FindByIdAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Snorkel snorkel = applicationDbContext.Snorkels
                .Include(snorkel => snorkel.SnorkelSupports)
                .FirstOrDefault(snorkel => snorkel.Id == id);
            if (snorkel.SnorkelSupports.Count(snorkel => snorkel.ApplicationUserId == applicationUser.Id) < 1)
            {
                snorkel.SnorkelSupports.Add(snorkelSupport);
            }
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
