using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace joaodias_generic.Application.DTOs
{

    public class CoinDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Buy Price is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Buy Price")]
        public decimal BuyPrice { get; set; }

        [Required(ErrorMessage = "The Sell Price is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Sell Price")]
        public decimal SellPrice { get; set; }

        [DisplayName("Variation")]
        public decimal Variation { get; set; }
    }
}
