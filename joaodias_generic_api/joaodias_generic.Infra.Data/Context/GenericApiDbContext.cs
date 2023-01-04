using joaodias_generic_api.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic.Infra.Data.Context
{
    public class GenericApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public GenericApiDbContext(DbContextOptions<GenericApiDbContext> options) : base(options)
        {

        }

        public DbSet<Coin> Coins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(GenericApiDbContext).Assembly);
        }
    }
}
