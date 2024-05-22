namespace BookCollection
{
    public static class BookFactory
    {
        public static Book CreateBook(string title, DateTime? publicationDate, IEnumerable<string> authors)
        {
            return new Book(title, publicationDate, authors);
        }
    }
}
