
using BookCollection.Contracts;

namespace BookCollection
{
    public class SortByTitleStrategy : ISortStrategy
    {
        public IEnumerable<Book> Sort(IEnumerable<Book> books)
        {
            return books.OrderBy(b => b.Title);
        }
    }
}
