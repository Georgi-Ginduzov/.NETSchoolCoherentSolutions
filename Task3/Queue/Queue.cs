namespace Queue
{
    public class Queue<T> : IQueue<T> where T : struct
    {
        private LinkedList<T> _list;

        public Queue()
        {
             _list = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty. You cannot Dequeue an empty queue!");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        public bool IsEmpty()
        {
            return !_list.Any();
        }
    }
}
