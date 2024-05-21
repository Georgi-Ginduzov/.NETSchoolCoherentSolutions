namespace Queue
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
        {
            var tempQueue = new Queue<T>();
            var tailedQueue = new Queue<T>();

            T item = queue.Dequeue();
            tempQueue.Enqueue(item);

            while (!queue.IsEmpty())
            {
                item = queue.Dequeue();
                tempQueue.Enqueue(item);
                tailedQueue.Enqueue(item);
            }

            // restore the original queue
            while (!tempQueue.IsEmpty())
            {
                queue.Enqueue(tempQueue.Dequeue());
            }

            return tailedQueue;
        }

    }
}
