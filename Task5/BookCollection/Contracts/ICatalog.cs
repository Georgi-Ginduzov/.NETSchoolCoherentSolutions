namespace BookCollection.Contracts
{
    public interface ICatalog : IEnumerable<Book>
    {
        void Add(string isbn, Book book);
        Book GetBook(string isbn);
        IEnumerable<string> GetSortedBookTitles();
        IEnumerable<Book> GetBooksByAuthor(string author);
        IEnumerable<(string Author, int BookCount)> GetAuthorBookCounts();


    }
}
