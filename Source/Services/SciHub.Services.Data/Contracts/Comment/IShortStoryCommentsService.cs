namespace SciHub.Services.Data.Contracts.Comment
{
    using System.Linq;
    using SciHub.Data.Models.Movie;
    using SciHub.Data.Models.ShortStory;

    public interface IShortStoryCommentsService
    {
        IQueryable<ShortStoryComment> GetAll();

        IQueryable<ShortStoryComment> GetAllByShortStoryId(int shortStoryId, int? size);

        ShortStoryComment GetById(int id);

        ShortStoryComment Add(string content, int shortStoryId, string userId);

        void Update(string content, int id);

        void Delete(int id);
    }
}
