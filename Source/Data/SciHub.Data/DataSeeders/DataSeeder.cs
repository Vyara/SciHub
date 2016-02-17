using SciHub.Data.Models.Common;
using SciHub.Data.Models.ShortStory;

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

            var dark = new Tag
            {
                Name = "dark"
            };

            var funny = new Tag
            {
                Name = "funny"
            };

            var sad = new Tag
            {
                Name = "sad"
            };

            var ai = new Tag
            {
                Name = "ai"
            };

            var aliens = new Tag
            {
                Name = "aliens"
            };

            context.Tags.Add(dark);
            context.Tags.Add(funny);
            context.Tags.Add(sad);
            context.Tags.Add(ai);
            context.Tags.Add(aliens);

            context.SaveChanges();


            var firstStory = new ShortStory
            {
                Title = "The Dawning",
                Content = @"Sed porttitor lectus nibh. Cras ultricies ligula sed magna dictum porta. Proin eget tortor risus. Nulla quis lorem ut libero malesuada feugiat. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Cras ultricies ligula sed magna dictum porta. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Pellentesque in ipsum id orci porta dapibus. Nulla quis lorem ut libero malesuada feugiat. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a.

                Curabitur non nulla sit amet nisl tempus convallis quis ac lectus.Donec sollicitudin molestie malesuada.Curabitur arcu erat,
                accumsan id imperdiet et,
                porttitor at sem.Cras ultricies ligula sed magna dictum porta.Pellentesque in ipsum id orci porta dapibus.Praesent sapien massa,
                convallis a pellentesque nec,
                egestas non nisi.Praesent sapien massa,
                convallis a pellentesque nec,
                egestas non nisi.Nulla porttitor accumsan tincidunt.Pellentesque in ipsum id orci porta dapibus.Vivamus magna justo,
                lacinia eget consectetur sed,
                convallis at tellus.",

                AuthorId = ada.Id,
            };

            var fistStoryRating = new ShortStoryRating
            {
                Value = 4,
                ShortStoryId = firstStory.Id,
                UserId = newton.Id
            };

            var firstStoryFirstComment = new ShortStoryComment
            {
                Content = "Very funny!",
                ShortStoryId = firstStory.Id,
                AuthorId = einstein.Id
            };

            var firstStorySecondComment = new ShortStoryComment
            {
                Content = "The main character was great.",
                ShortStoryId = firstStory.Id,
                AuthorId = turing.Id
            };

            firstStory.Ratings.Add(fistStoryRating);
            firstStory.Comments.Add(firstStoryFirstComment);
            firstStory.Comments.Add(firstStorySecondComment);
            firstStory.Tags.Add(funny);
            firstStory.Tags.Add(ai);

            var secondStory = new ShortStory
            {
                Title = "He knows",
                Content = @"Vivamus suscipit tortor eget felis porttitor volutpat. Proin eget tortor risus. Cras ultricies ligula sed magna dictum porta. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Nulla porttitor accumsan tincidunt. Donec rutrum congue leo eget malesuada. Vivamus suscipit tortor eget felis porttitor volutpat. Nulla quis lorem ut libero malesuada feugiat. Cras ultricies ligula sed magna dictum porta. Proin eget tortor risus. Donec rutrum congue leo eget malesuada.

Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Sed porttitor lectus nibh. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Donec rutrum congue leo eget malesuada. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Pellentesque in ipsum id orci porta dapibus. Nulla quis lorem ut libero malesuada feugiat. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Cras ultricies ligula sed magna dictum porta. Curabitur aliquet quam id dui posuere blandit. Cras ultricies ligula sed magna dictum porta.

Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Cras ultricies ligula sed magna dictum porta. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Sed porttitor lectus nibh. Donec rutrum congue leo eget malesuada. Donec sollicitudin molestie malesuada. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Donec rutrum congue leo eget malesuada. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus.",

                AuthorId = testFemaleUser.Id,
            };


            var secondStoryRating = new ShortStoryRating
            {
                Value = 5,
                ShortStoryId = secondStory.Id,
                UserId = einstein.Id
            };
            var secondStoryFirstComment = new ShortStoryComment
            {
                Content = "Intriguing!",
                ShortStoryId = secondStory.Id,
                AuthorId = ada.Id
            };


            secondStory.Ratings.Add(secondStoryRating);
            secondStory.Comments.Add(secondStoryFirstComment);
            secondStory.Tags.Add(dark);


            var thirdStory = new ShortStory
            {
                Title = "Into maddness",
                Content = @"Cras ultricies ligula sed magna dictum porta. Donec rutrum congue leo eget malesuada. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Curabitur aliquet quam id dui posuere blandit. Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Proin eget tortor risus. Vivamus suscipit tortor eget felis porttitor volutpat. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Cras ultricies ligula sed magna dictum porta. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                AuthorId = einstein.Id,
            };


            var thirdStoryFirstRating = new ShortStoryRating
            {
                Value = 3,
                ShortStoryId = thirdStory.Id,
                UserId = einstein.Id
            };

            var thirdStorySecondRating = new ShortStoryRating
            {
                Value = 5,
                ShortStoryId = thirdStory.Id,
                UserId = newton.Id
            };

            var thirdStoryComment = new ShortStoryComment
            {
                Content = "Great!",
                ShortStoryId = thirdStory.Id,
                AuthorId = testMaleUser.Id
            };


            thirdStory.Ratings.Add(thirdStoryFirstRating);
            thirdStory.Ratings.Add(thirdStorySecondRating);
            thirdStory.Comments.Add(thirdStoryComment);
            thirdStory.Tags.Add(aliens);
            thirdStory.Tags.Add(sad);



            context.ShortStories.Add(firstStory);
            context.ShortStories.Add(secondStory);
            context.ShortStories.Add(thirdStory);
            context.SaveChanges();

        }
    }
}
