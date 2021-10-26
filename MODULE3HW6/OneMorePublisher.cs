using System;
using System.Collections;
using System.Collections.Generic;

namespace MODULE3HW6
{
    public class OneMorePublisher
    {
        private object _locker;
        private Queue<int> _queue;

        public OneMorePublisher(Queue<int> queue, object locker)
        {
            _queue = queue;
            _locker = locker;
        }

        public void AddToQueue()
        {
            lock (_locker)
            {
                var random = new Random().Next(21, 40);
                _queue.Enqueue(random);
                Console.WriteLine($"{random} added from One More Publisher");
            }
        }
    }
}