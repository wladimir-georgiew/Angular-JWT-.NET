using ArtCave.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ArtCave.Web.Data
{
    public class DataSeeder
    {
        private class CategorySubcategories
        {
            public CategorySubcategories(string categoryName, List<string> subcategoryNames)
            {
                CategoryName = categoryName;
                SubcategoryNames = subcategoryNames;
            }

            public string CategoryName { get; set; } = string.Empty;

            public ICollection<string> SubcategoryNames { get; set; } = new List<string>();
        }

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

            await SeedRolesAsync(context,
                roles: new string[]
                {
                    Constants.Constants.IdentityRoles.FreeUser,
                    Constants.Constants.IdentityRoles.Customer,
                    Constants.Constants.IdentityRoles.Admin
                });

            await SeedUsersAndAssignToRolesAsync(context, userManager, new UserRoleDto[]
            {
                new UserRoleDto("admin@abv.bg", Constants.Constants.IdentityRoles.Admin)
            });

            SeedCategoriesAndSubcategories(context,
                categorySubcategoriesCollection: new List<CategorySubcategories>()
                {
                    new CategorySubcategories("Drawing", new List<string>()
                    {
                        "Graphite",
                        "Coal",
                        "Ink",
                    }),
                    new CategorySubcategories("Graphics", new List<string>()
                    {
                        "Lithography",
                        "Linocut",
                        "Dry Needle"
                    }),
                    new CategorySubcategories("Wall Painting", new List<string>()
                    {
                        "Iconography",
                        "Mosaic",
                        "Stained Glass Window"
                    }),
                    new CategorySubcategories("Painting", new List<string>()
                    {
                        "Watercolor",
                        "Oil",
                        "Tempera",
                        "Acryl",
                    }),
                    new CategorySubcategories("Sculpture", new List<string>()
                    {
                        "Wood",
                        "Ceramic",
                        "Glass",
                        "Porcelain",
                        "Metal",
                        "Clay"
                    }),
                     new CategorySubcategories("Textile", new List<string>()
                    {
                    }),
                    new CategorySubcategories("Digital Art", new List<string>()
                    {
                        "Illustration",
                        "Background",
                        "Character Design",
                    }),
                });

            SeedTags(context,
                tags: new string[]
                {
                    "anime", "emotional", "nature", "gaming", "landscape", "character", "book", "fashion", "aesthetic", "dark", "erotic"
                });

            await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(ArtCaveDbContext context, string[] roles)
        {
            foreach (string roleName in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    await roleStore.CreateAsync(new IdentityRole(roleName) { NormalizedName = roleName.ToUpper() });
                }
            }
        }

        /// <summary>
        /// Seed users and assigns the user to the given role
        /// <see />
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task SeedUsersAndAssignToRolesAsync(ArtCaveDbContext context, UserManager<ApplicationUser> userManager, UserRoleDto[] data)
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

                    var dbUser = await userManager.FindByEmailAsync(userRoleDto.UserEmail);
                    await userManager.AddToRoleAsync(dbUser, userRoleDto.RoleName);
                }
            }
        }

        private static void SeedCategoriesAndSubcategories(ArtCaveDbContext context, List<CategorySubcategories> categorySubcategoriesCollection)
        {
            foreach (var categorySubcategories in categorySubcategoriesCollection)
            {
                if (!context.Categories.Any(x => x.Name == categorySubcategories.CategoryName))
                {
                    context.Categories.Add(new Category() { Name = categorySubcategories.CategoryName });
                    context.SaveChanges();
                }

                if (categorySubcategories.SubcategoryNames.Any())
                {
                    foreach (var subcategoryName in categorySubcategories.SubcategoryNames)
                    {
                        if (!context.Subcategories.Any(x => x.Name == subcategoryName))
                        {
                            var categoryId = context.Categories.First(x => x.Name == categorySubcategories.CategoryName).Id;
                            context.Subcategories.Add(new Subcategory() { Name = subcategoryName, CategoryId = categoryId });
                        }
                    }
                }
            }
        }

        private static void SeedTags(ArtCaveDbContext context, string[] tags)
        {
            foreach (var tagName in tags)
            {
                if (!context.Tags.Any(x => x.Name == tagName))
                {
                    context.Tags.Add(new Tag() { Name = tagName });
                }
            }
        }

        private static async Task SeedCountriesAsync(ArtCaveDbContext context)
        {
            throw new NotImplementedException();
        }
    }

}
