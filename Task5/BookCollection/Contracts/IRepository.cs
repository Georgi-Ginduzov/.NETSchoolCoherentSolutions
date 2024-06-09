namespace BookCollection.Contracts
{
    public interface IRepository<T>
    {
        T Get();
        bool Save(T items);
    }
}
