using joaodias_generic.Domain.Validation;

namespace joaodias_generic.Domain.Entities
{
    public sealed class Coin : Entity
    {
        public string? Name { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Variation { get; set; }

        public Coin(string name, decimal buyPrice, decimal sellPrice, decimal variation)
        {
            ValidateDomain(name, buyPrice, sellPrice, variation);

        }

        public Coin(int id, string name, decimal buyPrice, decimal sellPrice, decimal variation)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, buyPrice, sellPrice, variation);

        }

        public void Update(string name, decimal buyPrice, decimal sellPrice, decimal variation)
        {
            ValidateDomain(name, buyPrice, sellPrice, variation);

        }

        private void ValidateDomain(string name, decimal buyPrice, decimal sellPrice, decimal variation)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. minimum 3 characters");
            DomainExceptionValidation.When(buyPrice < 0, "Invalid Buy Price value. No Negative values");
            DomainExceptionValidation.When(buyPrice > 99999.99M, "Invalid Buy Price value. Maximum Buy Price is 99999.99");
            DomainExceptionValidation.When(sellPrice < 0, "Invalid Sell Price value. No Negative values");
            DomainExceptionValidation.When(sellPrice > 99999.99M, "Invalid Sell Price value. Maximum Sell Price is 99999.99");

            Name = name;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Variation = variation;
        }
    }
}
