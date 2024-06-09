using BookCollection.Entities;

namespace BookCollection.Contracts
{
    public interface ICatalog : IEnumerable<Book>
    {
        void Add(object item);
        Dictionary<string, List<Book>> GetBooksByTheirAuthor();


    }
}
