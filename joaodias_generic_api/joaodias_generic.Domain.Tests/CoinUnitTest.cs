using FluentAssertions;
using Xunit;

namespace joaodias_generic.Domain.Tests
{
    public class CoinUnitTest
    {
        public class CategoryUnitTest1
        {

            [Fact(DisplayName = "Create Coin With Valid State")]
            public void CreateCategory_WithValidParameters_ResultObjectValidState()
            {
                Action action = () => new Coin(1, "Coin Name ");
                action.Should()
                     .NotThrow<joaodias_generic.Domain.Validation.DomainExceptionValidation>();
            }

            [Fact]
            public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
            {
                Action action = () => new Coin(-1, "Coin Name ");
                action.Should()
                    .Throw<joaodias_generic.Domain.Validation.DomainExceptionValidation>()
                     .WithMessage("Invalid Id value.");
            }

            /// <summary>
            /// Creates the category_ short name value_ domain exception short name.
            /// </summary>
            [Fact]
            public void CreateCategory_ShortNameValue_DomainExceptionShortName()
            {
                Action action = () => new Coin(1, "Ca");
                action.Should()
                    .Throw<joaodias_generic.Domain.Validation.DomainExceptionValidation>()
                       .WithMessage("Invalid name, too short, minimum 3 characters");
            }

            /// <summary>
            /// Creates the category_ missing name value_ domain exception required name.
            /// </summary>
            [Fact]
            public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
            {
                Action action = () => new Coin(1, "");
                action.Should()
                    .Throw<joaodias_generic.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name.Name is required");
            }

            /// <summary>
            /// Creates the category_ with null name value_ domain exception invalid name.
            /// </summary>
            [Fact]
            public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
            {
                Action action = () => new Coin(1, null);
                action.Should()
                    .Throw<joaodias_generic.Domain.Validation.DomainExceptionValidation>();
            }
        }
    }
}
