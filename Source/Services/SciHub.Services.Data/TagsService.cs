namespace SciHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SciHub.Services.Data.Contracts;
    using SciHub.Data.Common.Repositories;
    using SciHub.Data.Models.Common;

    public class TagsService : ITagsService
    {
        private readonly IDbRepository<Tag> tags;

        public TagsService(IDbRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> GetAll()
        {
            return this.tags.All()
           .OrderBy(m => m.Name);
        }

        public Tag GetById(int id)
        {
            var tag = this.tags.GetById(id);
            return tag;
        }
    }
}
