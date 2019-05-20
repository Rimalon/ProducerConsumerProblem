using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProducerConsumerProblem
{
    class Consumer
    {
        private volatile bool _isExit;
        private int _product;
        private List<int> _products;

        public Consumer(List<int> products)
        {
            _products = products;
            _isExit = false;
        }

        private bool GetProduct()
        {
            Monitor.Enter(_products);
            if (_products.Count > 0)
            {
                _product = _products.Last();
                _products.Remove(_products.Last());
                Monitor.Exit(_products);
                return true;
            }
            Monitor.Exit(_products);
            return false;
        }

        public void Run()
        {
            while (!_isExit)
            {
                if (GetProduct())
                {
                    Console.WriteLine("{0} get product: {1}", Thread.CurrentThread.Name, _product);
                    Thread.Sleep(1000);
                }
            }
        }

        public void Exit()
        {
            _isExit = true;
        }
    }
}
