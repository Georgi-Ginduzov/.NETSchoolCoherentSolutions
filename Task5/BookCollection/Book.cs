using System.Collections;
using System.Xml.Serialization;

namespace BookCollection
{
    public class Book// : IEnumerable
    {
        public Book()
        {
            
        }

        public Book(string title, DateTime? publicationDate, IEnumerable<string> authors)
        {
            CheckValidityOfData(title, publicationDate, authors);
            
            Title = title;
            PublicationDate = publicationDate;
            Authors = new HashSet<string>(authors ?? Enumerable.Empty<string>());
        }
       
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<string> Authors { get; set; }

        
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

        //public IEnumerator GetEnumerator() => (IEnumerator)this;
    }

}

 