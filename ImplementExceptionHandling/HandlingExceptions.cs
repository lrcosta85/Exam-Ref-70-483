using System;

namespace ImplementExceptionHandling
{
    public static class HandlingExceptions
    {
        static void Main(string[] args)
        {
            //UsingEnviromentFailFast();
            InspectingAnException();
            //Página 99
        }

        public static void UsingEnviromentFailFast()
        {
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);

                if (i == 42) Environment.FailFast("Special number entered");
            }
            finally
            {
                Console.WriteLine("Program completed");
            }
        }

        public static int ReadAndParse()
        {
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }
        public static void InspectingAnException()
        {
            try
            {
                int i = ReadAndParse();
                Console.WriteLine($"Parsed: {i}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                Console.WriteLine($"HelpLink: {e.HelpLink}");
                Console.WriteLine($"InnerException: {e.InnerException}");
                Console.WriteLine($"TargetSite: {e.TargetSite}");
                Console.WriteLine($"Source: {e.Source}");
            }
        }
    }
}
