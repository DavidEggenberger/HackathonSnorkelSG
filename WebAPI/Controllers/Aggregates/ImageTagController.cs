using Domain.ApplicationUserAggregate;
using Domain.ImageTagAggregate;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageTagController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext { get; }
        private UserManager<ApplicationUser> userManager { get; }
        public ImageTagController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageTag>> GetImageTagsForImage(Guid id)
        {
            return Ok(applicationDbContext.ImageTags
                .Include(imageTag => imageTag.Infos)
                .Where(imageTag => imageTag.Id == id));
        }

        [HttpPost("id")]
        [Authorize]
        public async Task<ActionResult> CreateImageTags(List<ImageTag> imageTags)
        {
            ApplicationUser applicationUser = await userManager.FindByIdAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok();
        }
    }
}
