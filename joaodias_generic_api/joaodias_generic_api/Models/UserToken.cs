using System;

namespace joaodias_generic.Api.Models
{
    /// <summary>
    /// The user token.
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
