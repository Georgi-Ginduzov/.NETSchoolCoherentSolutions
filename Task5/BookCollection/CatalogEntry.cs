namespace BookCollection
{
    public class CatalogEntry
    {
        public CatalogEntry()
        {
            Books = new List<BookEntry>();
        }

        public string? ISBN { get; set; }

        public List<BookEntry> Books { get; set; }
    }
}
