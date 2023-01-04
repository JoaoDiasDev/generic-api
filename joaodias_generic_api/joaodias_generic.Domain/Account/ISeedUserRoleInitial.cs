namespace joaodias_generic.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        /// <summary>
        /// Seeds the users.
        /// </summary>
        void SeedUsers();
        /// <summary>
        /// Seeds the roles.
        /// </summary>
        void SeedRoles();
    }
}
