namespace joaodias_generic_api.Data.Entities
{
    public class Coins
    {
        public int CoinsId { get; set; }

        public string CoinName { get; set; } = null!;

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }
        public decimal Variation { get; set; }
    }
}
