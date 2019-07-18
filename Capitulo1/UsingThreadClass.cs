using System;
using System.Threading;

namespace Capitulo1
{
    public static class Program
    {
        [ThreadStatic]
        public static int _field;
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);

            }
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);

            }
        }

        public static ThreadLocal<int> _localField =
            new ThreadLocal<int>(() =>
           {
               return Thread.CurrentThread.ManagedThreadId;
           });


        //static void Main(string[] args)
        //{
        //    //InicializarThread();
        //    //BackGroundThread();
        //    //ParameterizedThreadStart();
        //    //StoppingThread();
        //    //ThreadStaticAttribute();
        //    ThreadLocal();
        //}

        public static void InicializarThread()
        {
            Thread thread = new Thread(new ThreadStart(ThreadMethod));
            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: do some work");
                Thread.Sleep(0);
            }

            thread.Join();
        }

        public static void BackGroundThread()
        {
            Thread thread = new Thread(new ThreadStart(ThreadMethod));
            thread.IsBackground = false;
            thread.Start();
        }

        public static void ParameterizedThreadStart()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadMethod));
            thread.Start(5);
            thread.Join();
        }

        public static void StoppingThread()
        {
            bool stopped = false;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            thread.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;

            thread.Join();

        }

        public static void ThreadStaticAttribute()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread B: {_field}");
                }
            }).Start();

            Console.ReadKey();
        }

        public static void ThreadLocal()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _localField.Value; x++)
                {
                    Console.WriteLine($"Thread A: {x}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _localField.Value; x++)
                {
                    Console.WriteLine($"Thread B: {x}");
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
