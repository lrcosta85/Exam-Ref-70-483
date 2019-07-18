using System;
using System.Threading;

namespace Capitulo1
{
    public static class ThreadPools
    {
        //static void Main(string[] args)
        //{   
        //    QueueThreadPool();
        //}

        public static void QueueThreadPool()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }
    }


}
