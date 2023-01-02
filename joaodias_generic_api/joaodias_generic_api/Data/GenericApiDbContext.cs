using joaodias_generic_api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic_api.Data
{
    public class GenericApiDbContext : DbContext
    {
        public GenericApiDbContext(DbContextOptions<GenericApiDbContext> context) : base(context)
        {

        }

        public DbSet<Coins> Coins { get; set; }
    }
}
