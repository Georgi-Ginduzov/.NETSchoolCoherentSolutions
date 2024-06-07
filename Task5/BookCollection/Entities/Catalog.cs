using BookCollection.Contracts;
using System.Collections;
using System.Xml.Serialization;

namespace BookCollection.Entities
{
    [XmlRoot("Catalog")]
    public class Catalog : ICatalog
    {
        private Dictionary<string, Book> _books;
        
        public Catalog()
        {
            _books = new Dictionary<string, Book>();
        }

        public Book this[string isbn]
        {
            get => BookValidator.IsIsbnValid(isbn) ? _books[isbn] : null;//throw new ArgumentException("Invalid isbn\n");
        }

        public IReadOnlyCollection<Book> Books => _books.Values.ToList();


        public void Add(object item)
        {
            if (item is Book book)
            {
                Add(book);
            }
            else if (typeof(object) is IEnumerable<Book> books)
            {
                Add(books);
            }
            else
            {
                throw new ArgumentException("The item is not a book. It cannot be added to the catalog.");
            }
        }
        public void Add(Book book)
        {            
            book.ISBN = BookValidator.NormalizeIsbn(book.ISBN);

            try
            {
                if (_books[book.ISBN] != null)
                {
                    throw new ArgumentException("The book cannot be added to the catalog. Book with the same isbn already exists!");
                }
            }
            catch (KeyNotFoundException)
            {
                _books[book.ISBN] = book;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Add(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Add(book);
            }
        }

        public Dictionary<string, List<Book>> GetBooksByTheirAuthor()
        {
            var booksOfAuthors = new Dictionary<string, List<Book>>();

            foreach (var book in _books.Values)
            {
                //booksOfAuthors[author].Add(item);
            }

            return booksOfAuthors;
        }

        public IEnumerator<Book> GetEnumerator() => _books.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Catalog other = obj as Catalog;

            if (other.Books.Count != Books.Count)
            {
                return false;
            }

            for (int i = 0; i < Books.Count; i++)
            {
                if (Books.ElementAt(i).Equals(other.Books.ElementAt(i)))
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Books);
        }
    }
}
