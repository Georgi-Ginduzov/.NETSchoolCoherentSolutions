using BookCollection.Contracts;
using BookCollection.Entities;
using BookCollection.Repositories;

namespace BookCollectionTests
{
    public class JSONCatalogRepositorySerializationTest
    {
        private IRepository<Catalog> _jsonRepository;
        private IRepository<Catalog> _xmlRepository;
        private Catalog _catalog;

        [SetUp]
        public void Setup()
        {
            _jsonRepository = new JSONCatalogRepository();
            _xmlRepository = new XMLRepository<Catalog>();
            _catalog = new Catalog();

            var book1 =
                 new Book("978-0307474278", "One Hundred Years of Solitude", new DateTime(2006, 2, 21),
                 new List<Author> { new("Gabriel", "García Márquez", new DateTime(1927, 3, 6)) });
            var book2 =
                new Book("978-0451524935", "1984", new DateTime(1950, 1, 1),
                new List<Author> { new("George", "Orwell", new DateTime(1903, 6, 25)) });
            var book3 = new Book("978-0143039433", "The Great Gatsby", new DateTime(2004, 9, 30),
                new List<Author> { new("F. Scott", "Fitzgerald", new DateTime(1896, 9, 24)) });
            var book4 = new Book("978-0140177398", "To Kill a Mockingbird", new DateTime(1988, 10, 11),
                new List<Author> { new("Harper", "Lee", new DateTime(1926, 4, 28)) });
            var book5 = new Book("978-0679732761", "The Catcher in the Rye", new DateTime(1991, 5, 1), new List<Author> { new("J.D.", "Salinger", new DateTime(1919, 1, 1)) });

            _catalog.Add(book1);
            _catalog.Add(book2);
            _catalog.Add(book3);
            _catalog.Add(book4);
            _catalog.Add(book5);
        }

        [Test]
        public void JSONSerializationShouldSaveAndLoadDataCorrectly()
        {
            _jsonRepository.Save(_catalog);

            var loadedCatalog = _jsonRepository.Get();

            Assert.That (loadedCatalog, Is.Not.Null);

            Assert.That(loadedCatalog, Is.EqualTo(_catalog));
        }

        [Test]
        public void XMLSerializationShouldSaveAndLoadDataCorrectly()
        {
            _xmlRepository.Save(_catalog);

            var loadedCatalog = _xmlRepository.Get();

            Assert.That(loadedCatalog, Is.Not.Null);

            Assert.That(loadedCatalog, Is.EqualTo(_catalog));
        }
    }
}