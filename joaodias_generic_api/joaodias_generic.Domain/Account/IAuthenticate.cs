namespace joaodias_generic.Domain.Account
{
    public interface IAuthenticate
    {
        /// <summary>
        /// Authenticates the.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>A Task.</returns>
        Task<bool> Authenticate(string email, string password);

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>A Task.</returns>
        Task<bool> RegisterUser(string email, string password);

        /// <summary>
        /// Logouts the.
        /// </summary>
        /// <returns>A Task.</returns>
        Task Logout();
    }
}
