using BookCollection.Contracts;

namespace BookCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICatalog catalog = new Catalog();

            Book book1 = BookFactory.CreateBook("Book One", new DateTime(2001, 5, 20), new List<string> { "Author A", "Author B" });
            Book book2 = BookFactory.CreateBook("Book Two", new DateTime(1999, 8, 15), new List<string> { "Author A" });
            Book book3 = BookFactory.CreateBook("Book Three", new DateTime(2010, 3, 10), new List<string> { "Author C" });

            catalog.AddBook("123-4-56-789012-3", book1);
            catalog.AddBook("1234567890123", book2);
            catalog.AddBook("456-7-89-012345-6", book3);

            ISortStrategy sortStrategy = new SortByTitleStrategy();
            Console.WriteLine("Sorted book titles:");
            foreach (var title in sortStrategy.Sort(catalog.GetSortedBookTitles().Select(t => catalog.GetBook(t))))
            {
                Console.WriteLine(title.Title);
            }

            Console.WriteLine("\nBooks by Author A:");
            foreach (var book in catalog.GetBooksByAuthor("Author A"))
            {
                Console.WriteLine($"{book.Title} ({book.PublicationDate?.ToString("yyyy-MM-dd")})");
            }

            Console.WriteLine("\nAuthor book counts:");
            foreach (var (author, count) in catalog.GetAuthorBookCounts())
            {
                Console.WriteLine($"{author} - {count} book(s)");
            }
        }
    }
    
}
