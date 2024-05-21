namespace Queue
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
        {
            var tempQueue = queue;
            var newQueue = new Queue<T>();
            bool isFirst = true;

            if (queue.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            while (!tempQueue.IsEmpty())
            {
                T item = tempQueue.Dequeue();
                if (!isFirst)
                    newQueue.Enqueue(item);

                isFirst = false;
            }

            return newQueue;
        }
    }
}
