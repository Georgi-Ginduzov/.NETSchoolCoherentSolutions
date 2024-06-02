namespace BookCollection.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        bool SaveAll(IEnumerable<T> items);
    }
}
