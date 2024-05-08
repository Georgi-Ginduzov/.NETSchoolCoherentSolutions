using Queue;

namespace QueueTests
{
    public class QueueExtensionsTests
    {
        private Queue.Queue<int> _queue;

        [SetUp]
        public void Setup()
        {
            _queue = new Queue.Queue<int>();
        }

        [Test]
        public void Tail_ReturnsNewQueueWithoutFirstElement()
        {
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);

            var tailQueue = _queue.Tail();

            Assert.AreEqual(2, tailQueue.Dequeue());
            Assert.AreEqual(3, tailQueue.Dequeue());
            Assert.IsTrue(tailQueue.IsEmpty());
        }

        [Test]
        public void Tail_ThrowsExceptionWhenQueueIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Tail());
        }
    }
}
