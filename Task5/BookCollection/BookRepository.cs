using BookCollection.Contracts;
using System.Text.RegularExpressions;

namespace BookCollection
{
    public class BookRepository : IBookRepository
    {
        private Dictionary<string, Book> books;
        private static readonly Regex isbnFormat = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$|^\d{13}$");

        public BookRepository()
        {
            books = new Dictionary<string, Book>();
        }

        public void AddBook(string isbn, Book book)
        {
            if (!isbnFormat.IsMatch(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.");
            }

            string normalizedIsbn = NormalizeIsbn(isbn);
            books[normalizedIsbn] = book;
        }

        public Book GetBook(string isbn)
        {
            string normalizedIsbn = NormalizeIsbn(isbn);
            books.TryGetValue(normalizedIsbn, out var book);
            return book;
        }

        public IEnumerable<string> GetSortedBookTitles()
        {
            return books.Values.Select(b => b.Title).OrderBy(title => title);
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate);
        }

        public IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts()
        {
            return books.Values
                .SelectMany(b => b.Authors)
                .GroupBy(author => author)
                .Select(group => (Author: group.Key, BookCount: group.Count()));
        }

        private string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "");
        }
    }
}
