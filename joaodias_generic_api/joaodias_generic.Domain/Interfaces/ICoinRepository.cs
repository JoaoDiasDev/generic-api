using joaodias_generic.Domain.Entities;

namespace joaodias_generic.Domain.Interfaces
{
    public interface ICoinRepository
    {

        Task<IEnumerable<Coin>> GetCoinsAsync();

        Task<Coin> GetByIdAsync(int? id);

        Task<Coin> GetByNameAsync(string? name);

        Task<Coin> CreateAsync(Coin coin);

        Task<Coin> UpdateAsync(Coin coin);

        Task<Coin> RemoveAsync(Coin coin);
    }
}
