using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace ImplementExceptionHandling
{
    public static class ThrowningExceptions
    {
        static void Main(string[] args)
        {
            ExceptionDispatchInfoThrow();
        }

        public static void ExceptionDispatchInfoThrow()
        {
            ExceptionDispatchInfo possibleException = null;
            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
                //throw;
            }

            if(possibleException != null)
            {
                possibleException.Throw();
            }
        }
    }
}
