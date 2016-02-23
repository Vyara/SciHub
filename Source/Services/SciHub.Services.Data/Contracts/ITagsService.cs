namespace SciHub.Services.Data.Contracts
{
    using System.Linq;
    using SciHub.Data.Models.Common;

    public interface ITagsService
    {
        IQueryable<Tag> GetAll();

        Tag GetById(int id);
    }
}
