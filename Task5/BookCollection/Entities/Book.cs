namespace BookCollection.Entities
{
    public class Book
    {
        private string _title;
        private string _isbn;
        private HashSet<Author> _authors;

        public Book()
        {
        }

        public Book(string isbn, string title, DateTime? publicationDate, IEnumerable<Author> authors)
        {
            ISBN = isbn;
            Title = title;
            PublicationDate = publicationDate;
            Authors = new HashSet<Author>();
            Authors .UnionWith(authors);
        }

        public string ISBN 
        {
            get => _isbn; 
            set
            {                
                if (BookValidator.IsIsbnValid(value))
                {
                    throw new ArgumentException("ISBN code input is incorrect");
                }

                _isbn = value;
            }
        }
        public string Title 
        {
            get => _title; 
            set
            {
                if (!BookValidator.IsStringValid(value))
                {
                    throw new ArgumentException("Book's title cannot be null, empty or whitespace");
                }

                _title = value;
            }
        }
        public DateTime? PublicationDate 
        {
            get;
            set; 
        }
        public HashSet<Author> Authors
        {
            get => _authors;
            set
            {
                if (BookValidator.IsValidEnumerable(value))
                {
                    _authors = value;
                }
                else
                {
                    throw new ArgumentException("Authors list cannot be null");
                }
            }
        }
    }

}

