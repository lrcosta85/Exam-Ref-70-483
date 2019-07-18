using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capitulo1
{
    public static class UsingParallelClass
    {
        //static void Main(string[] args)
        //{
        //    ParallelFor();
        //    ParallelForEach();
        //}

        private static void ParallelFor()
        {
            Parallel.For(0, 10, i => {
                Thread.Sleep(1000);
            });
        }

        private static void ParallelForEach()
        {
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i => {
                Thread.Sleep(1000);
            });
        }

        private static void ParllelBreak()
        {
            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState parallelLoopState) => {
                if(i == 500)
                {
                    Console.WriteLine("Breaking Loop");
                    parallelLoopState.Break();
                }
                return;
            });

            
        }
    }
}
