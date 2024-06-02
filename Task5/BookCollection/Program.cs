using BookCollection.Contracts;
using BookCollection.Repositories;

namespace BookCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catalogs = new List<Catalog>();

            var firstCatalog = new Catalog();

            var book1 = new Book("The alchemist", new DateTime(2001, 5, 20), new List<string> { "Paulo Coelho"});
            var book2 = new Book("Atomic habits", new DateTime(1999, 8, 15), new List<string> { "James Clear" });
            var book3 = new Book("Good Omens", new DateTime(2010, 3, 10), new List<string> { "Terry Pratchett", "Neil Gaiman" });
            var book4 = new Book("Beautiful Creatures", new DateTime(2010, 3, 10), new List<string> { "Kami Garcia", "Margaretvar Stohl" });
            var book5 = new Book("Nick & Norah's Infinite Playlist", new DateTime(2010, 3, 10), new List<string> { "Rachel Cohn", "David Levithan" });

            firstCatalog.Add("123-4-56-789012-3", book1);
            firstCatalog.Add("1234568890123", book2);
            firstCatalog.Add("456-7-89-012345-6", book3);
            firstCatalog.Add("786-7-43-012345-6", book4);
            firstCatalog.Add("123-7-89-012345-6", book5);

            var secondCatalog = new Catalog();

            var book6 = new Book("The Valkyries", new DateTime(1992, 1, 1), new List<string> { "Paulo Coelho" });
            var book7 = new Book("Brida", new DateTime(1990, 1, 1), new List<string> { "Paulo Coelho" });
            var book8 = new Book("Good Omens", new DateTime(1990, 1, 1), new List<string> { "Terry Pratchett", "Neil Gaiman" });
            var book9 = new Book("American Gods", new DateTime(2001, 1, 1), new List<string> { "Neil Gaiman" });
            var book10 = new Book("Neverwhere", new DateTime(1996, 1, 1), new List<string> { "Neil Gaiman" });

            secondCatalog.Add("789-0-12-345678-9", book6);
            secondCatalog.Add("7890123456780", book7);
            secondCatalog.Add("012-3-45-678901-2", book8);
            secondCatalog.Add("345-6-78-901234-5", book9);
            secondCatalog.Add("678-9-01-234567-8", book10);

            catalogs.Add(firstCatalog);
            catalogs.Add(secondCatalog);

            //XMLRepository<Catalog> catalogRepository = new XMLRepository<Catalog>("C:\\Users\\Asus\\source\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Catalog.xml");
            XMLRepository<Catalog> repo = new XMLRepository<Catalog>("C:\\Users\\Asus\\source\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Data\\Catalog.xml");

            //repo.Save(firstCatalog);
            repo.SaveAll((IEnumerable<Catalog>)catalogs);
            
            

        }        
    }    
}
