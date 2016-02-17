namespace SciHub.Data.DataSeeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SciHub.Common;
    using SciHub.Common.Constants;
    using SciHub.Data.Models;
    using SciHub.Data.Models.Enumerators;


    internal static class DataSeeder
    {
        private static readonly Random random = new Random();

        internal static void SeedUserRoles(SciHubDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = UserRoleConstants.Default });
            roleManager.Create(new IdentityRole { Name = UserRoleConstants.Admin });

            context.SaveChanges();
        }

        internal static void SeedAdmin(SciHubDbContext context)
        {
            const string adminUserName = "theDecider666";
            const string adminPassword = "deciderd";

            if (context.Users.Any(u => u.UserName == adminUserName))
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var admin = new User
            {
                UserName = adminUserName,
                Email = "decider@admin.com",
                FirstName = "Admin",
                LastName = "Adminos",
                Avatar = UserDefaultPictureConstants.Female,
                Gender = Gender.Female,
                About = "I am the Decider!"
            };

            userManager.Create(admin, adminPassword);
            userManager.AddToRole(admin.Id, UserRoleConstants.Admin);
            userManager.AddToRole(admin.Id, UserRoleConstants.Default);

            context.SaveChanges();
        }

        internal static void SeedData(SciHubDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            const string defaultPassword = "default123";
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var webClient = new WebClient();

            var newton = new User
            {
                UserName = "TheLordOfGravity",
                Email = "TheLordOfGravity@gravity.com",
                FirstName = "Isaac",
                LastName = "Newton",
                Avatar =
                    "https://lh6.googleusercontent.com/-7kPxj5JfhT0/VE6WRbBqcqI/AAAAAAAAKFM/typmQq-_S5Y/Isaac%252520Newton%252520Religious%252520Views.jpg",
                Gender = Gender.Male,
                About = "The best physicist and mathmatician out there."
            };

            var einstein = new User
            {
                UserName = "TheNewLordOfGravity",
                Email = "TheNewLordOfGravity@gravity.com",
                FirstName = "Albert",
                LastName = "Einstein",
                Avatar =
                    "http://static8.bornrichimages.com/cdn2/500/500/91/c/wp-content/uploads/2014/04/Albert-Einstein-1921_thumb.jpg",
                Gender = Gender.Male,
                About = "The new best physicist and mathmatician out there."
            };

            var turing = new User
            {
                UserName = "CSIAmYourFather",
                Email = "CSIAmYourFather@compsci.com",
                FirstName = "Alan",
                LastName = "Turing",
                Avatar =
        "https://c4.staticflickr.com/4/3882/19046770766_073023b43f.jpg",
                Gender = Gender.Male,
                About = "Puzzles are easy for me."
            };


            var ada = new User
            {
                UserName = "CodingIAmYourMother",
                Email = "CodingAmYourMother@compsci.com",
                FirstName = "Ada",
                LastName = "Lovelace",
                Avatar =
        "https://40.media.tumblr.com/a1e0ee726344a22b21507d5673705328/tumblr_nz67nvweCf1smrroto1_500.jpg",
                Gender = Gender.Female,
                About = "Love punched tape!"
            };

            var paranoidAndroid = new User
            {
                UserName = "NothingMatters",
                Email = "nevermind@dontcare.com",
                FirstName = "Marvin",
                LastName = "None",
                Avatar = UserDefaultPictureConstants.Neutral,
                Gender = Gender.Other,
                About = "This will all end in tears."
            };

            var testMaleUser = new User
            {
                UserName = "IAmJustForTesting",
                Email = "IAmJustForTesting@test.com",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 3, 3),
                Avatar = UserDefaultPictureConstants.Male,
                Gender = Gender.Male,
                About = "Nothing to say."
            };

            var testFemaleUser = new User
            {
                UserName = "IAmAlsoJustForTesting",
                Email = "IAmAlsoJustForTesting@test.com",
                FirstName = "Jane",
                LastName = "Doe",
                BirthDate = new DateTime(1992, 2, 1),
                Avatar = UserDefaultPictureConstants.Female,
                Gender = Gender.Female,
                About = "Nothing to say."
            };


            userManager.Create(newton, defaultPassword);
            userManager.AddToRole(newton.Id, UserRoleConstants.Default);
            userManager.Create(einstein, defaultPassword);
            userManager.AddToRole(einstein.Id, UserRoleConstants.Default);
            userManager.Create(turing, defaultPassword);
            userManager.AddToRole(turing.Id, UserRoleConstants.Default);
            userManager.Create(ada, defaultPassword);
            userManager.AddToRole(ada.Id, UserRoleConstants.Default);
            userManager.Create(paranoidAndroid, defaultPassword);
            userManager.AddToRole(paranoidAndroid.Id, UserRoleConstants.Default);
            userManager.Create(testMaleUser, defaultPassword);
            userManager.AddToRole(testMaleUser.Id, UserRoleConstants.Default);
            userManager.Create(testFemaleUser, defaultPassword);
            userManager.AddToRole(testFemaleUser.Id, UserRoleConstants.Default);

            context.SaveChanges();
        }
    }
}
