using ArtCave.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ArtCave.Web.Data
{
    public class DataSeeder
    {
        private class UserRoleDto
        {
            public UserRoleDto(string userEmail, string roleName)
            {
                this.UserEmail = userEmail;
                this.RoleName = roleName;
            }

            public string UserEmail { get; set; }
            public string RoleName { get; set; }
        }

        public static async void Initialize(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ArtCaveDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new string[] {
                Constants.Constants.IdentityRoles.FreeUser,
                Constants.Constants.IdentityRoles.Customer,
                Constants.Constants.IdentityRoles.Admin };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role) { NormalizedName = role.ToUpper() });
                }
            }

            await SeedUsersAndRoles(context, userManager, new UserRoleDto[]
            {
                new UserRoleDto("admin@abv.bg", Constants.Constants.IdentityRoles.Admin)
            });


            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Seed users, roles and assigns the user to the role
        /// <see />
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task SeedUsersAndRoles(ArtCaveDbContext context, UserManager<ApplicationUser> userManager, UserRoleDto[] data)
        {
            foreach (var userRoleDto in data)
            {
                var user = new ApplicationUser
                {
                    UserName = userRoleDto.UserEmail,
                    Email = userRoleDto.UserEmail,
                    NormalizedEmail = userRoleDto.UserEmail.ToUpper(),
                    NormalizedUserName = userRoleDto.UserEmail.ToUpper(),
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };


                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "123123123");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<ApplicationUser>(context);

                    await userStore.CreateAsync(user);

                    await AssignUserToRole(userManager, user.Email, Constants.Constants.IdentityRoles.Admin);
                }
            }
        }

        private static async Task<IdentityResult> AssignUserToRole(UserManager<ApplicationUser> userManager, string email, string role)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, role);

            return result;
        }
    }

}
