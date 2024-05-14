namespace Queue
{
    public interface IQueue<T> where T : struct
    {
        void Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
    }
}