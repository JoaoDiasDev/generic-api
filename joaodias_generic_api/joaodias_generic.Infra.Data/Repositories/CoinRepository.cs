using joaodias_generic.Domain.Entities;
using joaodias_generic.Domain.Interfaces;
using joaodias_generic.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic.Infra.Data.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        GenericApiDbContext _genericApiDbContext;

        public CoinRepository(GenericApiDbContext context)
        {
            _genericApiDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Coin> CreateAsync(Coin coin)
        {
            _genericApiDbContext.Add(coin);
            await _genericApiDbContext.SaveChangesAsync();
            return coin;
        }


        public async Task<Coin> GetByIdAsync(int? id)
        {
            return await _genericApiDbContext.Coins.FindAsync(id);
        }

        public async Task<Coin> GetByNameAsync(string? name)
        {
            return await _genericApiDbContext.Coins.FindAsync(name);
        }


        public async Task<IEnumerable<Coin>> GetCoinsAsync()
        {
            return await _genericApiDbContext.Coins.ToListAsync();
        }

        public async Task<Coin> RemoveAsync(Coin coin)
        {
            _genericApiDbContext.Remove(coin);
            await _genericApiDbContext.SaveChangesAsync();
            return coin;
        }

        public async Task<Coin> UpdateAsync(Coin coin)
        {
            _genericApiDbContext.Update(coin);
            await _genericApiDbContext.SaveChangesAsync();
            return coin;
        }
    }
}
