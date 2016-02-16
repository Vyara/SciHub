namespace SciHub.Data.Models.Book
{
    using Common.Models;

    public class BookCover : BaseModel<int>
    {
        public byte[] Image { get; set; }

        public string ImageFileExtention { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
