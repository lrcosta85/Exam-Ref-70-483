using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capitulo1
{
    public static class ParallelLinq
    {
        //static void Main(string[] args)
        //{
        //    //UsingParallel();
        //    //UnorderedParallelQuery();
        //    //OrderedParallelQuery();
        //    //SequencialParalleQuery();
        //    //ForAllUsing();
        //    //CatchingAggregateException();
        //}
        public static void UsingParallel()
        {
            var number = Enumerable.Range(0, 100000);
            var parallelResult = number.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
        }
        public static void UnorderedParallelQuery()
        {
            var numbers = Enumerable.Range(0, 10);
            var parellelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (int i in parellelResult)
            {
                Console.WriteLine(i);
            }
        }
        public static void OrderedParallelQuery()
        {
            var numbers = Enumerable.Range(0, 10);
            var parellelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (int i in parellelResult)
            {
                Console.WriteLine(i);
            }
        }
        public static void SequencialParalleQuery()
        {
            var numbers = Enumerable.Range(0, 20);

            var paralleResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();

            foreach (int i in paralleResult.Take(5))
            {
                Console.WriteLine(i);
            }
        }
        public static void ForAllUsing()
        {
            var numbers = Enumerable.Range(0, 20);
            var paralleResult = numbers.AsParallel()
                .Where(i => i % 2 == 0);
            paralleResult.ForAll(e => Console.WriteLine(e));
        }

        public static void CatchingAggregateException()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel()
                    .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"There where {e.InnerExceptions.Count} exceptions");
            }
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }
}
