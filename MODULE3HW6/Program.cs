using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MODULE3HW6
{
    class Program
    {
        const int iter = 5;
        
        static void Main(string[] args)
        {
            var locker = new object();
            var queue = new Queue<int>();
            var publisher = new Publisher(queue, locker);
            var oneMorePublisher = new OneMorePublisher(queue, locker);
            var subscriber = new Subscriber(queue, locker);

            var first = new Task(() =>
            {
                for (int i = 0; i < iter; i++)
                {
                    publisher.AddToQueue();
                    Thread.Sleep(500);
                }
            });
            
            var second = new Task(() =>
            {
                for (int i = 0; i < iter; i++)
                {
                    oneMorePublisher.AddToQueue();
                    Thread.Sleep(1000);
                }
            });
            
            var third = new Task(() =>
            {
                while (true)
                {
                    subscriber.ReadAndDelete();;
                    Thread.Sleep(1500);
                }
            });
            
            first.Start();
            second.Start();
            third.Start();

            Task.WaitAll(first, second);

        }
    }
}