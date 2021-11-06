using Domain;
using Domain.ApplicationUserAggregate;
using Domain.ImageTagAggregate;
using Domain.ImageTagAggregate.InfoTypes;
using Domain.SnorkelAggregate;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Snorkel> Snorkels { get; set; }
        public DbSet<ActivityInfo> ActivityInfos { get; set; }
        public DbSet<DescriptionInfo> DescriptionInfos { get; set; }
        public DbSet<HistoryInfo> HistoryInfos { get; set; }

        public ApplicationDbContext(
           DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
