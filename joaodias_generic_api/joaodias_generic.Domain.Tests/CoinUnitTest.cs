using FluentAssertions;
using joaodias_generic.Domain.Entities;
using Xunit;

namespace joaodias_generic.Domain.Tests
{
    public class CoinUnitTest
    {
        public class CoinUnitTest1
        {

            [Fact(DisplayName = "Create Coin With Valid State")]
            public void CreateCoin_WithValidParameters_ResultObjectValidState()
            {
                Action action = () => new Coin(id: 1, name: "Coin Name", buyPrice: 8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                     .NotThrow<Validation.DomainExceptionValidation>();
            }

            [Fact(DisplayName = "Create Coin With Negative Id")]
            public void CreateCoin_NegativeIdValue_DomainExceptionInvalidId()
            {
                Action action = () => new Coin(id: -1, name: "Coin Name", buyPrice: 8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                    .Throw<Validation.DomainExceptionValidation>()
                     .WithMessage("Invalid Id value.");
            }

            [Fact(DisplayName = "Create Coin With Short Name")]
            public void CreateCoin_ShortNameValue_DomainExceptionShortName()
            {
                Action action = () => new Coin(id: 1, name: "Co", buyPrice: 8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                    .Throw<Validation.DomainExceptionValidation>()
                       .WithMessage("Invalid name, too short. minimum 3 characters");
            }

            [Fact(DisplayName = "Create Coin Without Name")]
            public void CreateCoin_MissingNameValue_DomainExceptionRequiredName()
            {
                Action action = () => new Coin(id: 1, name: "", buyPrice: 8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                    .Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name. Name is required");
            }

            [Fact(DisplayName = "Create Coin With Null Value Name")]
            public void CreateCoin_WithNullNameValue_DomainExceptionInvalidName()
            {
                Action action = () => new Coin(id: 1, name: null, buyPrice: 8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                    .Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name. Name is required");
            }

            [Fact(DisplayName = "Create Coin With Negative Buy Price")]
            public void CreateCoin_WithNegativeBuyPrice_DomainExceptionNegativeBuyPrice()
            {
                Action action = () => new Coin(id: 1, name: "Coin Name", buyPrice: -8.58M, sellPrice: 7.59M, variation: -0.25M);
                action.Should()
                    .Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Buy Price value. No Negative values");
            }

            [Fact(DisplayName = "Create Coin With Unreal Buy Price")]
            public void CreateCoin_WithUnrealBuyPrice_DomainExceptionNegativeBuyPrice()
            {
                Action action = () => new Coin(id: 1, name: "Coin Name", buyPrice: 100000.99M, sellPrice: 7.59M, variation: -0.25M);
                action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Buy Price value. Maximum Buy Price is 99999.99");
            }
            [Fact(DisplayName = "Create Coin With Negative Sell Price")]
            public void CreateCoin_WithNegativeSellPrice_DomainExceptionNegativeBuyPrice()
            {
                Action action = () => new Coin(id: 1, name: "Coin Name", buyPrice: 8.58M, sellPrice: -7.59M, variation: -0.25M);
                action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Sell Price value. No Negative values");
            }
            [Fact(DisplayName = "Create Coin With Unreal Sell Price")]
            public void CreateCoin_WithUnrealSellPrice_DomainExceptionNegativeBuyPrice()
            {
                Action action = () => new Coin(id: 1, name: "Coin Name", buyPrice: 8.58M, sellPrice: 100000.99M, variation: -0.25M);
                action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Sell Price value. Maximum Sell Price is 99999.99");
            }

        }
    }
}
