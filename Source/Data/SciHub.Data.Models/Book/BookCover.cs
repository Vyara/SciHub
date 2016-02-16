namespace SciHub.Data.Models.Book
{
    using Data.Common.Models;

    public class BookCover : BaseModel<int>
    {
        public byte[] Image { get; set; }

        public string ImageFileExtention { get; set; }

        public int BookId { get; set; }
    }
}
