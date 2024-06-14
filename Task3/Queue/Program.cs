namespace Queue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var queue = new Queue<int>();
                queue.Enqueue(1);
                queue.Enqueue(3);
                queue.Enqueue(5);
                queue.Enqueue(7);

                var tailQueue = queue.Tail<int>();

                while (!tailQueue.IsEmpty())
                {
                    Console.WriteLine(tailQueue.Dequeue());
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
