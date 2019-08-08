using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndCallbacks
{
    public static class UsingLambdaExpressions
    {
        static void Main(string[] args)
        {
            //UsingLambdaExpressionroCreateDelegate();
            //CreateLambdaMultipleStatements();
            ActionDelegate();
            //Página 85 - Using Events
        }

        #region Lambda expression to create a delegate
        public delegate int Calculate(int x, int y);
        public static void UsingLambdaExpressionroCreateDelegate()
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));

            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));

        }
        public static void CreateLambdaMultipleStatements()
        {
            Calculate calc =
                (x, y) =>
                {
                    Console.WriteLine("Adding Numbers");
                    return x + y;
                };
            int result = calc(3, 4);
        }

        public static void ActionDelegate()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            calc(3, 4);
        }


       
        #endregion
    }
}
