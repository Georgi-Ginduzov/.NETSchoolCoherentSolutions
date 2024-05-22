namespace BookCollection
{
    public class Book
    {
        public Book(string title, DateTime? publicationDate, IEnumerable<string> authors)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }

            Title = title;
            PublicationDate = publicationDate;
            Authors = new HashSet<string>(authors ?? Enumerable.Empty<string>());
        }
       
        public string Title { get; private set; }
        public DateTime? PublicationDate { get; private set; }
        public HashSet<string> Authors { get; private set; }
    }

}

