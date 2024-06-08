using BookCollection.Contracts;
using BookCollection.Entities;
using BookCollection.Repositories;

namespace BookCollection
{
    internal class Program
    {
        static void Main()
        {
            var catalog = new Catalog();
            var book1 =
                new Book("123-4-56-789012-3", "The alchemist", new DateTime(2001, 5, 20), 
                new List<Author> { new("Paulo", "Coelho", new DateTime(1965, 05, 07)) });
            var book2 = 
                new Book("1234568890123", "Atomic habits", new DateTime(1999, 8, 15), 
                new List<Author> { new("James", "Clear", new DateTime(1976, 02, 04)) });
            var book3 = new Book("456-7-89-012345-6", "Good Omens", new DateTime(2010, 3, 10), 
                new List<Author> { new("Terry", "Pratchett", new DateTime(1957, 04, 20)) });
            var book4 = new Book("786-7-43-012345-6", "Beautiful Creatures", new DateTime(2010, 3, 10), 
                new List<Author> { new("Kami", "Garcia", new DateTime(1949, 07, 11)),  new("Margaretvar", "Stohl", new DateTime(1968, 09, 09)) });
            var book5 = new Book("123-7-89-012345-6", "Nick & Norah's Infinite Playlist", new DateTime(2010, 3, 10), new List<Author> { new("Rachel", "Cohn", new DateTime(1978, 12, 30)), new("David", "Levithan", new DateTime(1985, 01, 03))});

            catalog.Add(book1);
            catalog.Add(book2);
            catalog.Add(book3);
            catalog.Add(book4);
            catalog.Add(book5);


            var xmlRepo = new XMLRepository<Catalog>();
            var xmlCatalog = xmlRepo.Get();
            xmlRepo.Save(xmlCatalog);
            
            var jsonCatalogRepo = new JSONCatalogRepository();
            jsonCatalogRepo.Save(catalog);
            var jsonCatalog = jsonCatalogRepo.GetCatalog();
            

        }        
    }    
}
