using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capitulo1
{
    public static class ConcurrentCollections
    {
        static void Main(string[] args)
        {
            //BlockingCollection();
            //ConcurrentBag();
            //EnumerableConcurrentBag();
            //UsingConcurrentStak();
            //UsingConcurrentQueue();
            //ConcurrentDictionary();

            //Página 55
        }
        #region BlockingCollection
        public static void BlockingCollection()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();
        }
        #endregion

        #region CurrentBag
        public static void ConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryPeek(out result))
                Console.WriteLine($"There is a next item: {result}");
        }

        public static void EnumerableConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }
        #endregion

        #region CurrentStak and ConcurrentQueue
        public static void UsingConcurrentStak()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine($"Popped: {result}");

            stack.PushRange(new int[] { 1, 2, 3, 4 });

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }
        public static void UsingConcurrentQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine($"Dequeued: {result}");
        }
        #endregion

        #region ConcurrentDictionary
        public static void ConcurrentDictionary()
        {
            var dict = new ConcurrentDictionary<string, int>();
            if(dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dict["k1"] = 42;

            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);
        }
        #endregion
    }
}
