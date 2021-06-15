
namespace Libraly.Data.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public int YearOfBook { get; set; }
        public int Count { get; set; }
        public string NameOfBook { get; set; }
        public string AuthorOfBook { get; set; }
        public string LittleDescription { get; set; }
        public string LongDescription { get; set; }
        public string PhotoUrl { get; set; }
        public string Genres { get; set; }
    }
}