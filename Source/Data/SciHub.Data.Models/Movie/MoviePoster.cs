namespace SciHub.Data.Models.Movie
{
    using Data.Common.Models;

    public class MoviePoster : BaseModel<int>
    {
        public byte[] Image { get; set; }

        public string ImageFileExtention { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
