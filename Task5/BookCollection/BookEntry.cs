namespace BookCollection
{
    public class BookEntry
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<string> Authors { get; set; }
    }
}
