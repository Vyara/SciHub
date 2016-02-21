using SciHub.Common.Constants.Models;

namespace SciHub.Data.DataSeeders
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SciHub.Common;
    using SciHub.Common.Constants;
    using Models;
    using Models.Book;
    using Models.Common;
    using Models.Enumerators;
    using Models.Movie;
    using Models.ShortStory;
    using Models.TvShow;

    internal static class DataSeeder
    {
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

            var cyborgs = new Tag
            {
                Name = "cyborgs"
            };

            var exploration = new Tag
            {
                Name = "exploration"
            };

            var timeTravel = new Tag
            {
                Name = "time travel"
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
            context.Tags.Add(cyborgs);
            context.Tags.Add(exploration);
            context.Tags.Add(timeTravel);

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

            dune.Ratings.Add(new BookRating
            {
                Value = 4,
                UserId = ada.Id,
            });

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

            // Actors
            var sigorney = new Actor
            {
                FirstName = "Sigorney",
                LastName = "Weaver",
                BirthDate = new DateTime(1949, 8, 10)
            };

            var linda = new Actor
            {
                FirstName = "Linda",
                LastName = "Hamilton",
                BirthDate = new DateTime(1956, 9, 26)
            };

            var daisy = new Actor
            {
                FirstName = "Daisy",
                LastName = "Ridley",
                BirthDate = new DateTime(1992, 4, 10)
            };

            var nancy = new Actor
            {
                FirstName = "Nancy",
                LastName = "Allen",
                BirthDate = new DateTime(1950, 6, 24)
            };

            var gina = new Actor
            {
                FirstName = "Gina",
                LastName = "Torres",
                BirthDate = new DateTime(1969, 4, 25)
            };

            var jonathan = new Actor
            {
                FirstName = "Jonathan",
                LastName = "Frakes",
                BirthDate = new DateTime(1952, 8, 19)
            };

            var tom = new Actor
            {
                FirstName = "Tom",
                LastName = "Skerritt",
                BirthDate = new DateTime(1933, 8, 25)
            };

            var arnold = new Actor
            {
                FirstName = "Arnold",
                LastName = "Schwarzenegger",
                BirthDate = new DateTime(1947, 7, 30)
            };

            var boyega = new Actor
            {
                FirstName = "John",
                LastName = "Boyega",
                BirthDate = new DateTime(1992, 3, 17)
            };

            var weller = new Actor
            {
                FirstName = "Peter",
                LastName = "Weller",
                BirthDate = new DateTime(1947, 6, 24)
            };

            var nathan = new Actor
            {
                FirstName = "Nathan",
                LastName = "Fillion",
                BirthDate = new DateTime(1971, 3, 27)
            };

            var patrick = new Actor
            {
                FirstName = "Patrick",
                LastName = "Stewart",
                BirthDate = new DateTime(1940, 7, 13)
            };

            var tennant = new Actor
            {
                FirstName = "David",
                LastName = "Tennant",
                BirthDate = new DateTime(1971, 4, 18)
            };

            var coleman = new Actor
            {
                FirstName = "Jenna",
                LastName = "Coleman",
                BirthDate = new DateTime(1986, 4, 27)
            };

            context.Actors.Add(sigorney);
            context.Actors.Add(daisy);
            context.Actors.Add(nancy);
            context.Actors.Add(gina);
            context.Actors.Add(jonathan);
            context.Actors.Add(tom);
            context.Actors.Add(arnold);
            context.Actors.Add(boyega);
            context.Actors.Add(weller);
            context.Actors.Add(nathan);
            context.Actors.Add(patrick);
            context.Actors.Add(linda);
            context.Actors.Add(tennant);
            context.Actors.Add(coleman);

            context.SaveChanges();

            // Directors

            var ridley = new Director
            {
                FirstName = "Ridley",
                LastName = "Scott",
                BirthDate = new DateTime(1937, 11, 30)
            };

            var cameron = new Director
            {
                FirstName = "James",
                LastName = "Cameron",
                BirthDate = new DateTime(1954, 8, 16)
            };

            var abrams = new Director
            {
                FirstName = "J.J.",
                LastName = "Abrams",
                BirthDate = new DateTime(1966, 6, 27)
            };

            var verhoven = new Director
            {
                FirstName = "Paul",
                LastName = "Verhoeven",
                BirthDate = new DateTime(1938, 7, 18)
            };

            var whedon = new Director
            {
                FirstName = "Joss",
                LastName = "Whedon",
                BirthDate = new DateTime(1964, 6, 23)
            };

            var frakes = new Director
            {
                FirstName = "Jonathan",
                LastName = "Frakes",
                BirthDate = new DateTime(1952, 8, 19)
            };

            var moffat = new Director
            {
                FirstName = "Steven",
                LastName = "Moffat",
                BirthDate = new DateTime(1961, 11, 18)
            };

            var wheatley = new Director
            {
                FirstName = "Ben",
                LastName = "Wheatley"
            };

            var landau = new Director
            {
                FirstName = "Les",
                LastName = "Landau"
            };

            var scheerer = new Director
            {
                FirstName = "Robert",
                LastName = "Scheerer"
            };

            context.Directors.Add(ridley);
            context.Directors.Add(cameron);
            context.Directors.Add(abrams);
            context.Directors.Add(verhoven);
            context.Directors.Add(whedon);
            context.Directors.Add(frakes);
            context.Directors.Add(wheatley);
            context.Directors.Add(moffat);
            context.Directors.Add(landau);
            context.Directors.Add(scheerer);

            context.SaveChanges();

            // Studios

            var fox = new MovieStudio
            {
                Name = "20th Century-Fox"
            };

            var universal = new MovieStudio
            {
                Name = "Universal Pictures"
            };

            var carolco = new MovieStudio
            {
                Name = "Carolco Pictures"

            };

            var lucas = new MovieStudio
            {
                Name = "Lucasfilm"

            };

            var metro = new MovieStudio
            {
                Name = "Metro-Goldwyn-Mayer"
            };

            var paramount = new MovieStudio
            {
                Name = "Paramount Pictures"
            };

            context.MovieStudios.Add(fox);
            context.MovieStudios.Add(universal);
            context.MovieStudios.Add(carolco);
            context.MovieStudios.Add(lucas);
            context.MovieStudios.Add(metro);
            context.MovieStudios.Add(paramount);

            context.SaveChanges();

            // Movies

            var alien = new Movie
            {
                Title = "Alien",
                Year = 1979,
                Summary = @"The commercial vessel Nostromo receives a distress call from an unexplored planet. After searching for survivors, the crew heads home only to realize that a deadly bioform has joined them.",
                DirectorId = ridley.Id,
                StudioId = fox.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("http://i.telegraph.co.uk/multimedia/archive/03064/Alien-intro_3064438b.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            alien.Ratings.Add(new MovieRating
            {
                Value = 5,
                UserId = newton.Id,
            });

            alien.Ratings.Add(new MovieRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });

            alien.Comments.Add(new MovieComment
            {
                Content = "Scary and intriguing all the way!",
                AuthorId = testMaleUser.Id
            });

            alien.Comments.Add(new MovieComment
            {
                Content = "Beautiful",
                AuthorId = paranoidAndroid.Id
            });

            alien.Actors.Add(sigorney);
            alien.Actors.Add(tom);

            alien.Tags.Add(aliens);
            alien.Tags.Add(space);
            alien.Tags.Add(dark);
            alien.Tags.Add(survival);

            var terminatorTwo = new Movie
            {
                Title = "Terminator 2: Judgment Day",
                Year = 1991,
                Summary = @"A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her young son, John Connor, from a more advanced cyborg, made out of liquid metal.",
                DirectorId = cameron.Id,
                StudioId = carolco.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("https://posterspy.com/wp-content/uploads/2014/08/TERMINATOR_POSTERSPY850px.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            terminatorTwo.Ratings.Add(new MovieRating
            {
                Value = 3,
                UserId = testFemaleUser.Id,
            });

            terminatorTwo.Ratings.Add(new MovieRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });

            terminatorTwo.Ratings.Add(new MovieRating
            {
                Value = 5,
                UserId = newton.Id,
            });

            terminatorTwo.Comments.Add(new MovieComment
            {
                Content = "Cyborgs and guns!",
                AuthorId = testMaleUser.Id
            });

            terminatorTwo.Comments.Add(new MovieComment
            {
                Content = "Thrilling!",
                AuthorId = ada.Id
            });

            terminatorTwo.Actors.Add(arnold);
            terminatorTwo.Actors.Add(nancy);

            terminatorTwo.Tags.Add(ai);
            terminatorTwo.Tags.Add(distopian);
            terminatorTwo.Tags.Add(cyborgs);

            var starWars = new Movie
            {
                Title = "Star Wars: Episode VII - The Force Awakens",
                Year = 2015,
                Summary = @"Three decades after the defeat of the Galactic Empire, a new threat arises. The First Order attempts to rule the galaxy and only a ragtag group of heroes can stop them, along with the help of the Resistance.",
                DirectorId = abrams.Id,
                StudioId = lucas.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("http://a.dilcdn.com/bl/wp-content/uploads/sites/6/2015/10/star-wars-force-awakens-official-poster.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            starWars.Ratings.Add(new MovieRating
            {
                Value = 3,
                UserId = turing.Id,
            });


            starWars.Actors.Add(daisy);
            starWars.Actors.Add(boyega);

            starWars.Tags.Add(space);

            var robocop = new Movie
            {
                Title = "Robocop",
                Year = 1987,
                Summary = @"In a dystopic and crime-ridden Detroit, a terminally wounded cop returns to the force as a powerful cyborg haunted by submerged memories.",
                DirectorId = verhoven.Id,
                StudioId = metro.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("http://www.goautographs.com/media/catalog/product/cache/1/image/800x/040ec09b1e35df139433887a97daa66f/2/2/22250MPMO.JPG"),
                    ImageFileExtention = "jpg"
                }
            };

            robocop.Ratings.Add(new MovieRating
            {
                Value = 5,
                UserId = testFemaleUser.Id,
            });

            robocop.Ratings.Add(new MovieRating
            {
                Value = 5,
                UserId = testMaleUser.Id,
            });


            robocop.Comments.Add(new MovieComment
            {
                Content = "Hands down best movie of all times!",
                AuthorId = testMaleUser.Id
            });

            robocop.Actors.Add(weller);
            robocop.Actors.Add(linda);

            robocop.Tags.Add(ai);
            robocop.Tags.Add(distopian);
            robocop.Tags.Add(cyborgs);

            var serenity = new Movie
            {
                Title = "Serenity",
                Year = 2005,
                Summary = @"The crew of the ship Serenity tries to evade an assassin sent to recapture one of their number who is telepathic.",
                DirectorId = whedon.Id,
                StudioId = universal.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("http://cdn.fontmeme.com/images/Serenity-Poster.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            serenity.Ratings.Add(new MovieRating
            {
                Value = 3,
                UserId = testFemaleUser.Id,
            });

            serenity.Ratings.Add(new MovieRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });


            serenity.Comments.Add(new MovieComment
            {
                Content = "Firefly!",
                AuthorId = paranoidAndroid.Id
            });

            serenity.Actors.Add(nathan);
            serenity.Actors.Add(gina);

            serenity.Tags.Add(space);
            serenity.Tags.Add(funny);

            var starTrek = new Movie
            {
                Title = "Star Trek: First Contact",
                Year = 1996,
                Summary = @"The Borg go back in time intent on preventing Earth's first contact with an alien species. Captain Picard and his crew pursue them to ensure that Zefram Cochrane makes his maiden flight reaching warp speed.",
                DirectorId = frakes.Id,
                StudioId = paramount.Id,
                Poster = new MoviePoster
                {
                    Image = webClient.DownloadData("http://i.imgur.com/pBiGr19.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            starTrek.Ratings.Add(new MovieRating
            {
                Value = 5,
                UserId = testFemaleUser.Id,
            });

            starTrek.Ratings.Add(new MovieRating
            {
                Value = 4,
                UserId = testMaleUser.Id,
            });


            starTrek.Comments.Add(new MovieComment
            {
                Content = "Best star trek movie",
                AuthorId = turing.Id
            });

            starTrek.Actors.Add(patrick);
            starTrek.Actors.Add(jonathan);

            starTrek.Tags.Add(space);
            starTrek.Tags.Add(aliens);
            starTrek.Tags.Add(dark);

            context.Movies.Add(alien);
            context.Movies.Add(terminatorTwo);
            context.Movies.Add(starWars);
            context.Movies.Add(robocop);
            context.Movies.Add(serenity);
            context.Movies.Add(starTrek);

            context.SaveChanges();

            // Channels

            var foxTv = new TvShowChannel
            {
                Name = "20th Century-Fox Television(Fox Tv)"
            };

            var nbc = new TvShowChannel
            {
                Name = "National Broadcasting Company(NBC)"
            };

            var bbc = new TvShowChannel
            {
                Name = "British Broadcasting Corporation(BBC)"
            };

            context.TvShowChannels.Add(foxTv);
            context.TvShowChannels.Add(nbc);
            context.TvShowChannels.Add(bbc);

            context.SaveChanges();

            // TvShows
            var firefly = new TvShow
            {
                Title = "Firefly",
                StartYear = 2002,
                EndYear = 2003,
                Summary = @"Five hundred years in the future, a renegade crew aboard a small spacecraft tries to survive as they travel the unknown parts of the galaxy and evade warring factions as well as authority agents out to get them.",
                ChannelId = foxTv.Id,
                Poster = new TvShowPoster
                {
                    Image = webClient.DownloadData("https://gooreviewsonline.files.wordpress.com/2012/11/firefly-poster-2.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            firefly.Ratings.Add(new TvShowRating
            {
                Value = 5,
                UserId = testFemaleUser.Id,
            });

            firefly.Ratings.Add(new TvShowRating
            {
                Value = 5,
                UserId = testMaleUser.Id,
            });


            firefly.Comments.Add(new TvShowComment
            {
                Content = "Very nice but only one season :(",
                AuthorId = turing.Id
            });

            firefly.Actors.Add(nathan);
            firefly.Actors.Add(gina);
            firefly.Directors.Add(whedon);

            firefly.Tags.Add(space);
            firefly.Tags.Add(funny);

            var starTrekTv = new TvShow
            {
                Title = "Star Trek: The Next Generation",
                StartYear = 1987,
                EndYear = 1994,
                Summary = @"Set decades after Captain Kirk's five-year mission, a new generation of Starfleet officers set off in a new Enterprise on their own mission to go where no one has gone before.",
                ChannelId = nbc.Id,
                Poster = new TvShowPoster
                {
                    Image = webClient.DownloadData("https://fanart.tv/fanart/tv/71470/tvposter/star-trek-the-next-generation-521b936d8d1d0.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            starTrekTv.Ratings.Add(new TvShowRating
            {
                Value = 5,
                UserId = testFemaleUser.Id,
            });

            starTrekTv.Ratings.Add(new TvShowRating
            {
                Value = 5,
                UserId = testMaleUser.Id,
            });


            starTrekTv.Comments.Add(new TvShowComment
            {
                Content = "The essential sci fi series",
                AuthorId = turing.Id
            });

            starTrekTv.Actors.Add(patrick);
            starTrekTv.Actors.Add(jonathan);
            starTrekTv.Directors.Add(landau);
            starTrekTv.Directors.Add(scheerer);

            starTrekTv.Tags.Add(space);
            starTrekTv.Tags.Add(exploration);


            var who = new TvShow
            {
                Title = "Doctor Who",
                StartYear = 2005,
                Summary = @"The further adventures of the time traveling alien adventurer and his companions.",
                ChannelId = bbc.Id,
                Poster = new TvShowPoster
                {
                    Image = webClient.DownloadData("http://merchandise.thedoctorwhosite.co.uk/wp-content/uploads/11-doctors-poster-1.jpg"),
                    ImageFileExtention = "jpg"
                }
            };

            who.Ratings.Add(new TvShowRating
            {
                Value = 4,
                UserId = testFemaleUser.Id,
            });

            who.Comments.Add(new TvShowComment
            {
                Content = "Very Entertaining!",
                AuthorId = turing.Id
            });

            who.Actors.Add(tennant);
            who.Actors.Add(coleman);
            who.Directors.Add(wheatley);
            who.Directors.Add(moffat);

            who.Tags.Add(space);
            who.Tags.Add(timeTravel);
            who.Tags.Add(funny);
            who.Tags.Add(aliens);

            context.TvShows.Add(firefly);
            context.TvShows.Add(starTrekTv);
            context.TvShows.Add(who);
            context.SaveChanges();
        }
    }
}
