﻿using Domain;
using Domain.Aggregates.Snorkel;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedContracts.Aggregates.Snorkel;
using System;
using System.Collections.Generic;
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
            return Ok(applicationDbContext.Snorkels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Snorkel>> GetSnorkelById(Guid id)
        {
            return Ok(applicationDbContext.Snorkels.Find(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateSnorkel(Snorkel snorkel)
        {
            ApplicationUser applicationUser = await userManager.FindByIdAsync(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Guid createdId = Guid.NewGuid();
            snorkel.Id = createdId;
            snorkel.ApplicationUserId = applicationUser.Id;
            applicationDbContext.Snorkels.Add(snorkel);
            await applicationDbContext.SaveChangesAsync();
            return CreatedAtAction("GetSnorkelById", new { id = createdId }, snorkel);
        }
    }
}
