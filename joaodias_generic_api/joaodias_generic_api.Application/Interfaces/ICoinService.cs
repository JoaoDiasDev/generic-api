using joaodias_generic.Application.DTOs;

namespace joaodias_generic.Application.Interfaces
{
    /// <summary>
    /// The category service.
    /// </summary>
    public interface ICoinService
    {

        Task<IEnumerable<CoinDTO>> GetCoins();

        Task<CoinDTO> GetById(int? id);
        Task<CoinDTO> GetByName(string? name);

        Task Add(CoinDTO coinDto);

        Task Update(CoinDTO coinDto);

        Task Remove(int? id);

    }
}
