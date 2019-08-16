using System;

namespace CreateTypes
{
    public static class CreatingCustomStruct
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //página 122
        }

        public struct Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

        }
    }
}

