namespace Queue
{
    public class Queue<T> : IQueue<T> where T : struct
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_list == null)
            {
                throw new NullReferenceException("Queue is not initialized in order to enqueue items to it!");
            }

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
