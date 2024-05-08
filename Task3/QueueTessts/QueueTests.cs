namespace QueueTessts
{
    public class Tests
    {
        private Queue.Queue<int> _queue;

        [SetUp]
        public void Setup()
        {
            _queue = new Queue.Queue<int>();
        }

        [Test]
        public void Enqueue_AddsElementToQueue()
        {
            _queue.Enqueue(1);
            Assert.IsFalse(_queue.IsEmpty());
        }

        [Test]
        public void Dequeue_RemovesElementFromQueue()
        {
            _queue.Enqueue(1);
            var dequeuedElement = _queue.Dequeue();
            Assert.AreEqual(1, dequeuedElement);
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void Dequeue_ThrowsExceptionWhenQueueIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void IsEmpty_ReturnsTrueWhenQueueIsEmpty()
        {
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void IsEmpty_ReturnsFalseWhenQueueIsNotEmpty()
        {
            _queue.Enqueue(1);
            Assert.IsFalse(_queue.IsEmpty());
        }
    }
}