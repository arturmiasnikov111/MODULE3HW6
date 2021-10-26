using System;
using System.Collections;
using System.Collections.Generic;

namespace MODULE3HW6
{
    public class Publisher
    {
        private object _locker;
        private Queue<int> _queue;

        public Publisher(Queue<int> queue, object locker)
        {
            _queue = queue;
            _locker = locker;
        }

        public void AddToQueue()
        {
            lock (_locker)
            {
                var random = new Random().Next(1, 20);
                _queue.Enqueue(random);
                Console.WriteLine($"{random} added from Publisher");
            }
        }
    }
}