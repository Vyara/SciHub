namespace SciHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models;
    using SciHub.Data.Models.Book;
    using SciHub.Data.Models.Common;
    using SciHub.Data.Models.ShortStory;
    using SciHub.Services.Data.Contracts;
    using SciHub.Services.Data.DataTransferObjects;

    public class ShortStoriesService : IShortStoriesService
    {
        private readonly IDbRepository<ShortStory> stories;
        private readonly IDbRepository<User> authors;
        private readonly IDbRepository<Tag> tags;


        public ShortStoriesService(IDbRepository<ShortStory> stories, IDbRepository<User> authors, IDbRepository<Tag> tags)
        {
            this.stories = stories;
            this.authors = authors;
            this.tags = tags;
        }

        public IQueryable<ShortStory> GetTop(int count)
        {
            var stories = this.stories.All()
                .OrderByDescending(m => (m.Ratings.Sum(r => r.Value) / m.Ratings.Count()))
                .ThenBy(m => m.CreatedOn)
                .Take(count);
            return stories;
        }

        public IQueryable<ShortStory> GetAll()
        {
            return this.stories.All()
                        .OrderByDescending(m => m.CreatedOn);
        }

        public PagedShortStoryDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria)
        {
            var allItemsCount = this.stories.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var allStories = this.stories.All();

            if (!string.IsNullOrEmpty(criteria))
            {
                allStories = allStories.Where(x => x.Title.Contains(criteria) || x.Content.Contains(criteria));
            }

            if (order == "newest")
            {
                allStories = allStories.OrderByDescending(x => x.CreatedOn);
            }
            else if (order == "top")
            {
                allStories = allStories.OrderByDescending(m => ((float)m.Ratings.Sum(r => r.Value) / m.Ratings.Count()));
            }

            allStories = allStories
                     .Skip(itemsToSkip)
                     .Take(itemsPerPage);

            var dto = new PagedShortStoryDto
            {
                AllItemsCount = allItemsCount,
                ShortStories = allStories,
                TotalPages = totalPages
            };

            return dto;
        }

        public ShortStory GetById(int id)
        {
            var story = this.stories.GetById(id);
            return story;
        }

        public ShortStory Add(ShortStory story)
        {
            story.Ratings.Add(new ShortStoryRating()
            {
                Value = 5
            });

            this.stories.Add(story);

            this.stories.SaveChanges();

            return story;
        }

        public void Delete(ShortStory story)
        {
            this.stories.Delete(story);
            this.stories.SaveChanges();
        }

        public IQueryable<ShortStory> Update(ShortStory story)
        {
            this.stories.Update(story);
            this.stories.SaveChanges();

            return this.stories.All().Where(m => m.Id == story.Id);
        }

        public void Rate(int storyId, float value, string userId)
        {
            var story = this.stories.GetById(userId);

            if (story != null)
            {
                story.Ratings.Add(new ShortStoryRating()
                {
                    Value = value,
                    UserId = userId
                });
            }

            this.stories.SaveChanges();
        }

        public ICollection<ShortStory> GetTagStories(int tagId)
        {
            var stories = this.tags.GetById(tagId).ShortStories;
            return stories;
        }

        public ICollection<ShortStory> GetAuthorStories(string authorId)
        {
            var stories = this.authors.GetById(authorId).ShortStories;
            return stories;
        }
    }
}
