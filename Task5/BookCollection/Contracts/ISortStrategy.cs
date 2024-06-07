using BookCollection.Entities;

namespace BookCollection.Contracts
{
    public interface ISortStrategy
    {
        IEnumerable<Book> Sort(IEnumerable<Book> books);
    }
}
