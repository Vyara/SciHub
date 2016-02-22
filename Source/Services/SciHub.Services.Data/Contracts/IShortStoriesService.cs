namespace SciHub.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Data.Models.Book;
    using SciHub.Data.Models.ShortStory;
    using SciHub.Services.Data.DataTransferObjects;

    public interface IShortStoriesService
    {
        IQueryable<ShortStory> GetTop(int count);

        IQueryable<ShortStory> GetAll();

        PagedShortStoryDto GetAllWithPaging(int page, int itemsPerPage, string order, string criteria);

        ShortStory GetById(int id);

        ShortStory Add(ShortStory story);

        void Delete(ShortStory story);

        IQueryable<ShortStory> Update(ShortStory story);

        void Rate(int storyId, float value, string userId);

        ICollection<ShortStory> GetTagStories(int tagId);

        ICollection<ShortStory> GetAuthorStories(string authorId);
    }
}
