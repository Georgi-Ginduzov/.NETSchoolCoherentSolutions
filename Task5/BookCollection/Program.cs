using BookCollection.Contracts;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BookCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICatalog catalog = new Catalog();

            var book1 = new Book("The alchemist", new DateTime(2001, 5, 20), new List<string> { "Paulo Coelho"});
            var book2 = new Book("Atomic habits", new DateTime(1999, 8, 15), new List<string> { "James Clear" });
            var book3 = new Book("Good Omens", new DateTime(2010, 3, 10), new List<string> { "Terry Pratchett", "Neil Gaiman" });
            var book4 = new Book("Beautiful Creatures", new DateTime(2010, 3, 10), new List<string> { "Kami Garcia", "Margaretvar Stohl" });
            var book5 = new Book("Nick & Norah's Infinite Playlist", new DateTime(2010, 3, 10), new List<string> { "Rachel Cohn", "David Levithan" });

            catalog.AddBook("123-4-56-789012-3", book1);
            catalog.AddBook("1234568890123", book2);
            catalog.AddBook("456-7-89-012345-6", book3);
            catalog.AddBook("786-7-43-012345-6", book4);
            catalog.AddBook("123-7-89-012345-6", book5);

            
            
        }

        
    }
    
}
