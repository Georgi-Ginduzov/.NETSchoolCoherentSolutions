using System.Linq;
using System.Text;

namespace BookCollection
{
    public class Book
    {
        public Book(string title, DateTime? publicationDate, IEnumerable<string> authors)
        {
            CheckValidityOfData(title, publicationDate, authors);
            
            Title = title;
            PublicationDate = publicationDate;
            Authors = new SortedSet<string>(authors ?? Enumerable.Empty<string>());
        }
       
        public string Title { get; private set; }
        public DateTime? PublicationDate { get; private set; }
        public SortedSet<string> Authors { get; private set; }

        private void CheckValidityOfData(string title, DateTime? publicationDate, IEnumerable<string> authors)
        {
            if (String.IsNullOrWhiteSpace(title) || title.Length == 0)
            {
                throw new ArgumentException("Title cannot be null, whitespace or empty.");
            }

            if (!publicationDate.HasValue)
            {
                throw new ArgumentException("Date should be valid.");
            }

            if (authors == null || authors.Count() == 0)
            {
                throw new ArgumentException("Authors cannot be null or empty.");
            }
        }

        public override string ToString()
        {
            StringBuilder book = new StringBuilder();
            book.Append(Title + " (" + PublicationDate?.ToString("yyyy-MM-dd") + ") by ");
            foreach (var author in Authors)
            {
                book.Append(author + ", ");
            }
            book.AppendLine();

            return book.ToString().Trim();
        }
    }

}

