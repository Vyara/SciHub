namespace SciHub.Data.Models.TvShow
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;
    using SciHub.Common.Constants.Models;

    public class TvShowChannel : BaseModel<int>
    {
        private ICollection<TvShow> tvShows;

        public TvShowChannel()
        {
            this.tvShows = new HashSet<TvShow>();
        }

        [Required]
        [MinLength(TvShowModelConstants.ChannelNameMinLenght)]
        [MaxLength(TvShowModelConstants.ChannelNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<TvShow> TvShows
        {
            get { return this.tvShows; }
            set { this.tvShows = value; }
        }
    }
}
