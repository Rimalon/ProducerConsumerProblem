using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<int>();

            int numberOfProducer = 3;
            int numberOfConsumer = 10;

            Producer[] producers = new Producer[numberOfProducer];
            Consumer[] consumers = new Consumer[numberOfConsumer];

            Console.WriteLine("Press any key to stop working");

            for (int i = 0; i< producers.Length; ++i)
            {
                producers[i] = new Producer(products);
                new Thread(producers[i].Run) { Name = "Producer #" + i }.Start();
            }

            for (int i = 0; i < consumers.Length; ++i)
            {
                consumers[i] = new Consumer(products);
                new Thread(consumers[i].Run) { Name = "Consumer #" + i }.Start();
            }

            Console.ReadKey();

            for (int i = 0; i < numberOfConsumer; i++)
            {
                consumers[i].Exit();
            }

            for (int i = 0; i < numberOfProducer; i++)
            {
                producers[i].Exit();
            }
        }
    }
}
