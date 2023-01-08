using ArtCave.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ArtCave.Web.Data
{
    public class DataSeeder
    {
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

            await SeedUsersAndRoles(context, userManager, new Tuple<string, string>[]
            {
                new Tuple<string,string>("admin@abv.bg", Constants.Constants.IdentityRoles.Admin)
            });


            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Seed users, roles and assigns the user to the role
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <param name="emailRoleKvps"></param>
        /// <returns></returns>
        private static async Task SeedUsersAndRoles(ArtCaveDbContext context, UserManager<ApplicationUser> userManager, Tuple<string, string>[] emailRoleKvps)
        {
            foreach (var emailRoleKvp in emailRoleKvps)
            {
                var user = new ApplicationUser
                {
                    UserName = emailRoleKvp.Item1,
                    Email = emailRoleKvp.Item1,
                    NormalizedEmail = emailRoleKvp.Item1.ToUpper(),
                    NormalizedUserName = emailRoleKvp.Item1.ToUpper(),
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

                    await AssignUserToAdminRole(userManager, user.Email);
                }
            }
        }

        private static async Task<IdentityResult> AssignUserToAdminRole(UserManager<ApplicationUser> userManager, string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, Constants.Constants.IdentityRoles.Admin);

            return result;
        }
    }

}
