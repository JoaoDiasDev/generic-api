using joaodias_generic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joaodias_generic.Infra.Data.EntitiesConfiguration
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.SellPrice).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.BuyPrice).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
