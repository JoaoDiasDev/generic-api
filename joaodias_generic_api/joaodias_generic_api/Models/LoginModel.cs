using System.ComponentModel.DataAnnotations;

namespace joaodias_generic.Api.Models
{
    /// <summary>
    /// The login model.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max " +
            "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
