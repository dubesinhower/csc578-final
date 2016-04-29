namespace CSC578Final.Models
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Extensions.DependencyInjection;

    public static class SampleData
    {
        private static BlogContext context;
        private static readonly string[] Roles = { "Administrator", "User" };
       private static readonly BlogUser User = new BlogUser { UserName = "JohnCena", SecurityStamp = Guid.NewGuid().ToString() };
        

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            context = serviceProvider.GetService<BlogContext>();

            await CreateSampleRoles();
            await CreateSampleUsers();
            await AssignRoles(serviceProvider);
            CreateSamplePosts();
        }

        private static async Task CreateSampleRoles()
        {

            foreach (string role in Roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task CreateSampleUsers()
        {
            if (!context.Users.Any(u => u.UserName == User.UserName))
            {
                var password = new PasswordHasher<BlogUser>();
                var hashed = password.HashPassword(User, "password");
                User.PasswordHash = hashed;

                var userStore = new UserStore<BlogUser>(context);
                await userStore.CreateAsync(User);
            }

            await context.SaveChangesAsync();
        }

        private static async Task<IdentityResult> AssignRoles(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<BlogUser>>();
            return await userManager.AddToRolesAsync(User, Roles);
        }

        private static void CreateSamplePosts()
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(new Post()
                                           {
                    AuthorId = User.Id,
                    Title = "First!",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis ex eros, semper at tincidunt id, pharetra nec nisi. Quisque sit amet eros justo. Donec efficitur est in dignissim sollicitudin. Vestibulum volutpat turpis ac mi laoreet varius. Curabitur ut magna bibendum, hendrerit ipsum ut, iaculis leo. Donec nec condimentum purus, id congue odio. Ut facilisis nec enim a venenatis. Aenean consequat ac ex nec mattis. Suspendisse venenatis lobortis neque ac tincidunt. Donec vestibulum elementum tellus ut volutpat. Suspendisse volutpat, magna eu efficitur dapibus, magna lorem consequat ipsum, quis eleifend metus eros non ex. Aliquam condimentum vel urna in pellentesque. Vestibulum quis erat tempus, elementum quam ut, euismod justo.",
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                }, new Post()
                       {
                    AuthorId = User.Id,
                    Title = "Another Blog Post",
                    Body = "Aenean sagittis est libero, et tempor urna tempor id. Maecenas dignissim libero leo, mattis congue orci hendrerit a. Sed quis est accumsan enim gravida consectetur. Ut orci neque, maximus id imperdiet id, vulputate eu lorem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras eget dapibus orci. Morbi faucibus est magna, tincidunt sollicitudin felis scelerisque a. Vivamus ut maximus risus. Phasellus id ultrices orci. Phasellus semper enim vel metus tincidunt ultricies. Vivamus pellentesque magna eget vehicula volutpat. Aenean sit amet tellus venenatis, consequat mauris at, ultricies nibh. Fusce vel mi sit amet neque dignissim gravida sed dictum massa.",
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                }, new Post()
                {
                    AuthorId = User.Id,
                    Title = "On a Roll!",
                    Body = "Sed placerat tellus lacus, ut placerat arcu luctus sed. Proin tristique mi eget diam condimentum pharetra. Nulla facilisi. Aliquam ut justo a arcu auctor aliquet. Proin eget felis vitae risus euismod efficitur in et ipsum. Quisque congue mauris sit amet urna varius consequat. Proin eleifend nisi sem, et tristique odio luctus nec.",
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                }, new Post()
                {
                    AuthorId = User.Id,
                    Title = "Ayy Lmao",
                    Body = "Duis fringilla dolor magna, imperdiet tempor est molestie ut. Vivamus ut ullamcorper mauris. Aliquam quis sollicitudin leo. Integer sollicitudin scelerisque felis id auctor. Nunc efficitur ut purus et aliquam. Etiam dictum vitae lectus rhoncus semper. Donec dapibus libero eget varius dapibus. Etiam in nulla vitae mi posuere rutrum. Donec dui est, posuere vehicula lacus at, tempus pretium leo. Pellentesque elit ante, pretium quis diam in, maximus semper neque. Mauris porta id libero quis mattis. Sed vel risus ac tortor blandit maximus ac scelerisque est.",
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                }, new Post()
                {
                    AuthorId = User.Id,
                    Title = "Isn't This a Great Blog?",
                    Body = "Duis fringilla dolor magna, imperdiet tempor est molestie ut. Vivamus ut ullamcorper mauris. Aliquam quis sollicitudin leo. Integer sollicitudin scelerisque felis id auctor. Nunc efficitur ut purus et aliquam. Etiam dictum vitae lectus rhoncus semper. Donec dapibus libero eget varius dapibus. Etiam in nulla vitae mi posuere rutrum. Donec dui est, posuere vehicula lacus at, tempus pretium leo. Pellentesque elit ante, pretium quis diam in, maximus semper neque. Mauris porta id libero quis mattis. Sed vel risus ac tortor blandit maximus ac scelerisque est.",
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                });
                context.SaveChanges();
            }
        }

    }
}
