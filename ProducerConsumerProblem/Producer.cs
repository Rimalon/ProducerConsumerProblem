using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerProblem
{
    class Producer
    {
        private int _product;
        private List<int> _products;
        private volatile bool _isExit;
        private Random _generator;

        public Producer(List<int> products)
        {
            _products = products;
            _isExit = false;
            _generator = new Random(DateTime.Now.Millisecond);
        }

        private void PutProduct()
        {
            _product = _generator.Next(1000);
            Monitor.Enter(_products);
            _products.Add(_product);
            Monitor.Exit(_products);
        }

        public void Run()
        {
            while (!_isExit)
            {
                PutProduct();
                Console.WriteLine("{0} put product: {1}", Thread.CurrentThread.Name, _product);
                Thread.Sleep(1000);
            }
        }

        public void Exit()
        {
            _isExit = true;
        }
    }
}
