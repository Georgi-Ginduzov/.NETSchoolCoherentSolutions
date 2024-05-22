using BookCollection.Contracts;
using BookCollection;

namespace Tests.BookCollectionTests
{
    public class AdditionalTests
    {
        private IBookRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new BookRepository();
        }

        [Test]
        public void AddBook_ShouldAddBookToRepository()
        {
            var book = BookFactory.CreateBook("Test Book", new DateTime(2020, 1, 1), new List<string> { "Author A" });
            repository.AddBook("123-4-56-789012-3", book);

            var retrievedBook = repository.GetBook("123-4-56-789012-3");
            Assert.AreEqual("Test Book", retrievedBook.Title);
        }

        [Test]
        public void GetBook_ShouldReturnBookRegardlessOfIsbnFormat()
        {
            var book = BookFactory.CreateBook("Test Book", new DateTime(2020, 1, 1), new List<string> { "Author A" });
            repository.AddBook("123-4-56-789012-3", book);

            var retrievedBook = repository.GetBook("1234567890123");
            Assert.AreEqual("Test Book", retrievedBook.Title);
        }

        [Test]
        public void GetSortedBookTitles_ShouldReturnTitlesInAlphabeticalOrder()
        {
            var book1 = BookFactory.CreateBook("C Book", new DateTime(2020, 1, 1), new List<string> { "Author A" });
            var book2 = BookFactory.CreateBook("A Book", new DateTime(2020, 1, 1), new List<string> { "Author B" });
            var book3 = BookFactory.CreateBook("B Book", new DateTime(2020, 1, 1), new List<string> { "Author C" });

            repository.AddBook("123-4-56-789012-3", book1);
            repository.AddBook("123-4-56-789013-4", book2);
            repository.AddBook("123-4-56-789014-5", book3);

            var sortedTitles = repository.GetSortedBookTitles().ToList();
            Assert.AreEqual("A Book", sortedTitles[0]);
            Assert.AreEqual("B Book", sortedTitles[1]);
            Assert.AreEqual("C Book", sortedTitles[2]);
        }

        [Test]
        public void GetBooksByAuthor_ShouldReturnBooksSortedByPublicationDate()
        {
            var book1 = BookFactory.CreateBook("Book 1", new DateTime(2020, 1, 1), new List<string> { "Author A" });
            var book2 = BookFactory.CreateBook("Book 2", new DateTime(2019, 1, 1), new List<string> { "Author A" });
            var book3 = BookFactory.CreateBook("Book 3", new DateTime(2021, 1, 1), new List<string> { "Author A" });

            repository.AddBook("123-4-56-789012-3", book1);
            repository.AddBook("123-4-56-789013-4", book2);
            repository.AddBook("123-4-56-789014-5", book3);

            var booksByAuthor = repository.GetBooksByAuthor("Author A").ToList();
            Assert.AreEqual("Book 2", booksByAuthor[0].Title);
            Assert.AreEqual("Book 1", booksByAuthor[1].Title);
            Assert.AreEqual("Book 3", booksByAuthor[2].Title);
        }

        [Test]
        public void GetAuthorBookCounts_ShouldReturnCorrectCounts()
        {
            var book1 = BookFactory.CreateBook("Book 1", new DateTime(2020, 1, 1), new List<string> { "Author A", "Author B" });
            var book2 = BookFactory.CreateBook("Book 2", new DateTime(2020, 1, 1), new List<string> { "Author A" });
            var book3 = BookFactory.CreateBook("Book 3", new DateTime(2020, 1, 1), new List<string> { "Author C" });

            repository.AddBook("123-4-56-789012-3", book1);
            repository.AddBook("123-4-56-789013-4", book2);
            repository.AddBook("123-4-56-789014-5", book3);

            var authorBookCounts = repository.GetAuthorBookCounts().ToList();
            var authorACount = authorBookCounts.First(a => a.Author == "Author A").BookCount;
            var authorBCount = authorBookCounts.First(a => a.Author == "Author B").BookCount;
            var authorCCount = authorBookCounts.First(a => a.Author == "Author C").BookCount;

            Assert.AreEqual(2, authorACount);
            Assert.AreEqual(1, authorBCount);
            Assert.AreEqual(1, authorCCount);
        }

        [Test]
        public void AddBook_ShouldThrowExceptionForInvalidIsbn()
        {
            var book = BookFactory.CreateBook("Test Book", new DateTime(2020, 1, 1), new List<string> { "Author A" });

            Assert.Throws<ArgumentException>(() => repository.AddBook("123-4-56-78901", book));
        }

        [Test]
        public void AddBook_ShouldThrowExceptionForEmptyTitle()
        {
            var book = new Book("", new DateTime(2020, 1, 1), new List<string> { "Author A" });

            Assert.Throws<ArgumentException>(() => repository.AddBook("123-4-56-789012-3", book));
        }

        [Test]
        public void AddBook_ShouldThrowExceptionForNullTitle()
        {
            var book = new Book(null, new DateTime(2020, 1, 1), new List<string> { "Author A" });

            Assert.Throws<ArgumentException>(() => repository.AddBook("123-4-56-789012-3", book));
        }

        [Test]
        public void GetBooksByAuthor_ShouldHandleEmptyAuthorCollection()
        {
            var book = BookFactory.CreateBook("Test Book", new DateTime(2020, 1, 1), new List<string>());
            repository.AddBook("123-4-56-789012-3", book);

            var booksByAuthor = repository.GetBooksByAuthor("NonExistent Author").ToList();
            Assert.IsEmpty(booksByAuthor);
        }

        [Test]
        public void GetSortedBookTitles_ShouldHandleEmptyCatalog()
        {
            var sortedTitles = repository.GetSortedBookTitles().ToList();
            Assert.IsEmpty(sortedTitles);
        }

        [Test]
        public void GetAuthorBookCounts_ShouldHandleEmptyCatalog()
        {
            var authorBookCounts = repository.GetAuthorBookCounts().ToList();
            Assert.IsEmpty(authorBookCounts);
        }
    }
}
