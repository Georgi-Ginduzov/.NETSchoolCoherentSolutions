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
                new Book("123-4-56-789012-3", "The alchemist", new DateTime(2001, 5, 20), new List<Author> { new("Paulo", "Coelho", new DateTime(05 / 07 / 1965)) });
            var book2 = 
                new Book("1234568890123", "Atomic habits", new DateTime(1999, 8, 15), 
                new List<Author> { new("James", "Clear", new DateTime(02/04/1976)) });
            var book3 = new Book("456-7-89-012345-6", "Good Omens", new DateTime(2010, 3, 10), 
                new List<Author> { new("Terry", "Pratchett", new DateTime(20/04/1957)) });
            var book4 = new Book("786-7-43-012345-6", "Beautiful Creatures", new DateTime(2010, 3, 10), 
                new List<Author> { new("Kami", "Garcia", new DateTime(07/11/1949)),  new("Margaretvar", "Stohl", new DateTime(20/09/1968)) });
            var book5 = new Book("123-7-89-012345-6", "Nick & Norah's Infinite Playlist", new DateTime(2010, 3, 10), new List<Author> { new("Rachel", "Cohn", new DateTime(30/12/1978)), new("David", "Levithan", new DateTime(01/03/1985))});

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
