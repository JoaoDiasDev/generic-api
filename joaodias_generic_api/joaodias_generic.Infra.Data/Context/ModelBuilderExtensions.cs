using joaodias_generic.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace joaodias_generic.Infra.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void SeedIdendity(this ModelBuilder modelBuilder)
        {
            //Create Roles
            List<IdentityRole> roles = new List<IdentityRole>() {
            new IdentityRole { Name = "User", NormalizedName = "USER"},
            new IdentityRole {Name = "Admin", NormalizedName = "ADMIN" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            //Create Users
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    UserName = "usuario@gmail.com",
                    Email = "usuario@gmail.com",
                    NormalizedUserName = "USUARIO@GMAIL.COM",
                    NormalizedEmail = "USUARIO@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            //Create Password to Users
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "#Joao1687*");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "#Joao1687*");

            //Update Users Roles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "User").Id
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);



        }
    }
}
