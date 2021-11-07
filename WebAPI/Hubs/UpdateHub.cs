using Domain.ApplicationUserAggregate;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    [Authorize]
    public class UpdateHub : Hub
    {
        private UserManager<ApplicationUser> userManager;
        public UpdateHub(UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
        }
        public override async Task OnConnectedAsync()
        {
            
        }
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            ApplicationUser appUser = await userManager.FindByIdAsync(Context.User.FindFirst("sub")?.Value);
            appUser.CheckedInSnorkelId = string.Empty;
            await userManager.UpdateAsync(appUser);
            await Clients.All.SendAsync("Update");
        }
        public async Task CheckIn(string SnorkelId)
        {
            ApplicationUser appUser = await userManager.FindByIdAsync(Context.User.FindFirst("sub")?.Value);
            appUser.CheckedInSnorkelId = SnorkelId;
            await userManager.UpdateAsync(appUser);
            await Clients.All.SendAsync("Update");
        }
        public async Task CheckOut()
        {
            ApplicationUser appUser = await userManager.FindByIdAsync(Context.User.FindFirst("sub")?.Value);
            appUser.CheckedInSnorkelId = string.Empty;
            await userManager.UpdateAsync(appUser);
            await Clients.All.SendAsync("Update");
        }
    }
}
