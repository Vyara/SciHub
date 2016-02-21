namespace SciHub.Web.ViewModels.Tags
{
    using Data.Models.Common;
    using Infrastructure.Mapping;

    public class TagViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}