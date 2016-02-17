using SciHub.Data.Models.Book;
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

            // Users 
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

            // Tags
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

            var planet = new Tag
            {
                Name = "planet"
            };


            var space = new Tag
            {
                Name = "space"
            };

            var distopian = new Tag
            {
                Name = "distopian"
            };

            var zombies = new Tag
            {
                Name = "zombies"
            };

            var apocalypitc = new Tag
            {
                Name = "apocalyptic"
            };


            var survival = new Tag
            {
                Name = "survival"
            };

            var cyberpunk = new Tag
            {
                Name = "cyberpunk"
            };

            context.Tags.Add(dark);
            context.Tags.Add(funny);
            context.Tags.Add(sad);
            context.Tags.Add(ai);
            context.Tags.Add(aliens);
            context.Tags.Add(planet);
            context.Tags.Add(space);
            context.Tags.Add(distopian);
            context.Tags.Add(zombies);
            context.Tags.Add(apocalypitc);
            context.Tags.Add(survival);
            context.Tags.Add(cyberpunk);

            context.SaveChanges();

            // Short Stories
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

            var webClient = new WebClient();

            // Books
            var herbert = new BookAuthor
            {
                FirstName = "Frank",
                LastName = "Herbert",
                BirthDate = new DateTime(1920, 10, 8)
            };

            var orwell = new BookAuthor
            {
                FirstName = "George",
                LastName = "Orwell",
                BirthDate = new DateTime(1903, 1, 23)
            };


            var gibson = new BookAuthor
            {
                FirstName = "William",
                LastName = "Gibson",
                BirthDate = new DateTime(1948, 3, 17)
            };

            context.BookAuthors.Add(herbert);
            context.BookAuthors.Add(orwell);
            context.BookAuthors.Add(gibson);

            context.SaveChanges();

            var dune = new Book
            {
                Title = "Dune",
                PublicationYear = 1965,
                Summary = @"Set in the far future amidst a sprawling feudal interstellar empire where planetary dynasties are controlled by noble houses that owe an allegiance to the imperial House Corrino, Dune tells the story of young Paul Atreides (the heir apparent to Duke Leto Atreides and heir of House Atreides) as he and his family accept control of the desert planet Arrakis, the only source of the 'spice' melange, the most important and valuable substance in the cosmos. The story explores the complex, multi-layered interactions of politics, religion, ecology, technology, and human emotion as the forces of the empire confront each other for control of Arrakis.",
                AuthorId = herbert.Id,
                Cover = new BookCover
                {
                    Image = webClient.DownloadData("https://upload.wikimedia.org/wikipedia/en/5/5a/FrankHerbert_Dune_1st.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            dune.Tags.Add(planet);
            dune.Tags.Add(space);

            var ninety = new Book
            {
                Title = "1984",
                PublicationYear = 1949,
                Summary = @"The year 1984 has come and gone, but George Orwell's prophetic, nightmarish vision in 1949 of the world we were becoming is timelier than ever. 1984 is still the great modern classic of negative utopia -a startlingly original and haunting novel that creates an imaginary world that is completely convincing, from the first sentence to the last four words. No one can deny the novel's hold on the imaginations of whole generations, or the power of its admonitions -a power that seems to grow, not lessen, with the passage of time.",
                AuthorId = orwell.Id,
                Cover = new BookCover
                {
                    Image = webClient.DownloadData("https://upload.wikimedia.org/wikipedia/en/c/c3/1984first.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            ninety.Ratings.Add(new BookRating
            {
                Value = 5,
                UserId = einstein.Id,
            });

            ninety.Ratings.Add(new BookRating
            {
                Value = 3,
                UserId = paranoidAndroid.Id,
            });

            ninety.Comments.Add(new BookComment
            {
                Content = "One of the best",
                AuthorId = testFemaleUser.Id
            });

            ninety.Tags.Add(distopian);

            var neuromancer = new Book
            {
                Title = "Neuromancer",
                PublicationYear = 1984,
                Summary = @"The Matrix is a world within the world, a global consensus- hallucination, the representation of every byte of data in cyberspace",
                AuthorId = gibson.Id,
                Cover = new BookCover
                {
                    Image = webClient.DownloadData("https://upload.wikimedia.org/wikipedia/en/4/4b/Neuromancer_(Book).jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            neuromancer.Ratings.Add(new BookRating
            {
                Value = 5,
                UserId = newton.Id,
            });

            neuromancer.Ratings.Add(new BookRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });

            neuromancer.Comments.Add(new BookComment
            {
                Content = "Futuristic genious",
                AuthorId = testFemaleUser.Id
            });

            neuromancer.Comments.Add(new BookComment
            {
                Content = "Loved it!",
                AuthorId = paranoidAndroid.Id
            });

            neuromancer.Tags.Add(cyberpunk);


            var mnemonic = new Book
            {
                Title = "Johnny Mnemonic",
                PublicationYear = 1981,
                Summary = @"Johnny is a courier. He carries data, uploaded into his brain through a jack implanted in his skull. And so Johnny's troubles begin. The data is stolen, and to get it back the owners have hired the Yakuza who intend to get hold of Johnny. But all they really need is his cryogenically frozen head.",
                AuthorId = gibson.Id,
                Cover = new BookCover
                {
                    Image = webClient.DownloadData("https://www.outerplaces.com/images/user_upload/covers7.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            mnemonic.Ratings.Add(new BookRating
            {
                Value = 3,
                UserId = newton.Id,
            });

            mnemonic.Ratings.Add(new BookRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });

            mnemonic.Comments.Add(new BookComment
            {
                Content = "Amazing",
                AuthorId = testMaleUser.Id
            });

            mnemonic.Comments.Add(new BookComment
            {
                Content = "Words cannot describe how I love this book",
                AuthorId = paranoidAndroid.Id
            });

            mnemonic.Tags.Add(cyberpunk);

            context.Books.Add(dune);
            context.Books.Add(ninety);
            context.Books.Add(neuromancer);
            context.Books.Add(mnemonic);
            context.SaveChanges();

        }
    }
}
