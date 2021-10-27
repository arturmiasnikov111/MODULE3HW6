using System;
using System.Collections.Generic;

namespace MODULE3HW6
{
    public class Subscriber
    {
        private Queue<int> _queue;
        private object _locker;

        public Subscriber(Queue<int> queue, object locker)
        {
            _queue = queue;
            _locker = locker;
        }

        public void ReadAndDelete()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            lock (_locker)
            {
                Console.WriteLine($"{_queue.Dequeue()} deleted from queue");
            }
        }
    }
}