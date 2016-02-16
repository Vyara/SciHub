namespace SciHub.Data.Models.TvShow
{
    using Data.Common.Models;

    public class TvShowPoster : BaseModel<int>
    {
        public byte[] Image { get; set; }

        public string ImageFileExtention { get; set; }

        public int TvShowId { get; set; }
    }
}
