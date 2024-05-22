using BookCollection.Contracts;

namespace BookCollection
{
    public class SortByPublicationDateStrategy : ISortStrategy
    {
        public IEnumerable<Book> Sort(IEnumerable<Book> books)
        {
            return books.OrderBy(b => b.PublicationDate);
        }
    }
}
