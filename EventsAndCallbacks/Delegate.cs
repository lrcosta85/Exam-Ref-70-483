using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EventsAndCallbacks
{
    public static class Delegate
    {
        //static void Main(string[] args)
        //{
        //    MulticastDelegate();
        //}

        #region useDelegate
        public delegate int Calculate(int x, int y);
        public static int Add(int x, int y) { return x + y; }
        public static int Multiply(int x, int y) { return x * y; }

        public static void UsingDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(3, 4));
        }
        #endregion

        #region multicastDelegate
        public static void Metodo1()
        {
            Console.WriteLine("Método 1");
        }
        public static void Metodo2()
        {
            Console.WriteLine("Método 2");
        }

        public delegate void Del();

        public static void MulticastDelegate()
        {
            Del d = Metodo1;
            d += Metodo2;

            int invocationCount = d.GetInvocationList().GetLength(0);

            Console.WriteLine(invocationCount);

            d();
        }

        #endregion

        #region convariance with delegates
        public delegate TextWriter ConvarianceDel();
        public static StreamWriter MethodStream() { return null; }
        public static StringWriter MethodString() { return null; }

        public static void ConvarianceWithDelegates()
        {
            ConvarianceDel del;
            del = MethodStream;
            del = MethodString;
        }

        #endregion

        #region contravariance with delegates
        public static void DoSomething(TextWriter tw) { }
        public delegate void ContravarianceDel(StreamWriter tw);
        public static void ContravarianceWithDelegates()
        {
            ContravarianceDel del = DoSomething;
        }
        #endregion




    }
}
