using BookCollection.Contracts;
using BookCollection.Repositories;
using System.Collections;
using System.Text.RegularExpressions;

namespace BookCollection
{                                 
    public class Catalog : ICatalog
    {
        private Dictionary<string, Book> _books;
        private static readonly Regex _isbnFormat = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$");

        public Catalog()
        {
            _books = new Dictionary<string, Book>();
        }

        public List<BookEntry> CatalogEntry
        {
            get => _books
                .Select(kv => new BookEntry 
                    { 
                      ISBN = kv.Key, 
                      Title = kv.Value.Title,
                      PublicationDate = kv.Value.PublicationDate,
                      Authors = kv.Value.Authors.ToList(),
                    })
                .ToList();
            set => _books = value.
                ToDictionary(
                        entry => entry.ISBN, 
                        entry => new Book(entry.Title, entry.PublicationDate, entry.Authors)
                        );
        }

        public void Add(string isbn, Book book)
        {
            if (!_isbnFormat.IsMatch(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.");
            }

            if (_books.ContainsKey(isbn))
            {
                throw new Exception("Book with the same isbn already exists!");
            }

            string normalizedIsbn = NormalizeIsbn(isbn);
            _books[normalizedIsbn] = book;
        }

        public void Add(object o)
        {

        }

        public Book GetBook(string isbn)
        {
            string normalizedIsbn = NormalizeIsbn(isbn);
            _books.TryGetValue(normalizedIsbn, out var book);
            return book;
        }

        public IEnumerable<string> GetSortedBookTitles()
        {
            return _books.Values.Select(b => b.Title).OrderBy(title => title);
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate);
        }

        public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
        {
            return _books.Values
                .SelectMany(b => b.Authors)
                .GroupBy(author => author)
                .Select(group => (Author: group.Key, BookCount: group.Count()));
        }

        private string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "");
        }

        
        public void SaveAll()
        {
            XMLRepository<CatalogEntry> entity = new XMLRepository<CatalogEntry>("C:\\Users\\Asus\\source\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Data\\Catalog.xml");

            //entity.SaveAll(CatalogEntry);
        }

        
        public IEnumerator<Book> GetEnumerator() => _books.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
