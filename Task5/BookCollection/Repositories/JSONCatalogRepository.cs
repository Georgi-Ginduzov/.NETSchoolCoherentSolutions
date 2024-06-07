using BookCollection.Entities;
using System.Text.Json;

namespace BookCollection.Repositories
{
    public class JSONCatalogRepository : JSONRepository<Catalog>
    {
        public JSONCatalogRepository()
        {
        }

        public Catalog GetCatalog() 
        {
            var catalog = new Catalog();

            foreach (var filePath in Directory.EnumerateFiles(_filePath))
            {
                var booksFromFile = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(filePath));

                foreach (var book in booksFromFile)
                {
                    try
                    {
                        catalog.Add(book);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
             
            }

            return catalog;
        }

        public bool Save(Catalog catalog)
        {
            foreach (var author in catalog.Books.SelectMany(book => book.Authors).Distinct())
            {
                var books = catalog.Books.Where(book => book.Authors.Contains(author)).ToList();
                var catalogToSave = new Catalog();
                catalogToSave.Add(books);

                
                string fileName = $"{author.FirstName}_{author.LastName}.json";
                if (!File.Exists(_filePath + fileName))
                {
                    File.Create(fileName).Close();
                }
                
                
                string jsonString = JsonSerializer.Serialize(catalogToSave);
                File.WriteAllText(_filePath + fileName, jsonString);

            }
            return true;
        }
    }
}
