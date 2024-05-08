namespace Queue
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue)
        {
            var newQueue = new Queue<T>();
            bool isFirst = true;

            if (queue.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            while (!queue.IsEmpty())
            {
                T item = queue.Dequeue();
                if (!isFirst)
                    newQueue.Enqueue(item);

                isFirst = false;
            }

            return newQueue;
        }
    }
}
