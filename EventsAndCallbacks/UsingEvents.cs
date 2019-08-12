using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsAndCallbacks
{
    public static class UsingEvents
    {
        static void Main(string[] args)
        {
            //CreateAndRaise();
            //CreateAndRaiseV2();
            CreateAndRaiseException();
        }

        #region Using action to expose an event
        public class Pub
        {
            //public Action OnChange { get; set; }

            //public void Raise()
            //{
            //    if (OnChange != null)
            //    {
            //        OnChange();
            //    }
            //}
            public event Action OnChange = delegate { };
            //public delegate void EventHandler(object sender, EventArgs e);
            public void Raise()
            {
                OnChange();
            }
        }

        public static void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");

            p.Raise();
        }
        #endregion

        #region Custom event arguments
        public class MyArgs : EventArgs
        {
            public int Value { get; set; }
            public MyArgs(int value)
            {
                Value = value; 
            }
        }

        public class Pub2
        {
            public event EventHandler<MyArgs> OnChange = delegate { };
            public void Raise()
            {
                OnChange(this, new MyArgs(42));
            }
        }

        public static void CreateAndRaiseV2()
        {
            Pub2 p = new Pub2();

            p.OnChange += (sender, e)
                => Console.WriteLine($"Event raised: {e.Value}");

            p.Raise();
        }

        #endregion

        #region Custom event accessor
        public class Pub3
        {
            private event EventHandler<MyArgs> onChange = delegate { };
            public event EventHandler<MyArgs> OnChange
            {
                add
                {
                    lock (onChange)
                    {
                        onChange += value;
                    }
                }
                remove
                {
                    lock (onChange)
                    {
                        onChange -= value;
                    }
                }
            }
            public void Raise()
            {
                onChange(this, new MyArgs(42));
            }
        }

        #endregion

        #region Exception when raising an event
        public class PubException
        {
            public event EventHandler OnChange = delegate { };
            public void Raise()
            {
                OnChange(this, EventArgs.Empty);
            }
        }

        public static void CreateAndRaiseException()
        {
            PubException p = new PubException();

            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 1 called");

            p.OnChange += (sender, e)
                =>
            { throw new Exception(); };

            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 3 called");

            p.Raise();
        }

        #endregion

        #region Manually raising events with exception handling
        //public class PubManually
        //{
        //    public event EventHandler OnChange = delegate {};

        //    public void Raise()
        //    {
        //        var exceptions = new List<Exception>();

        //        foreach (Delegate handler in OnChange.GetInvocationList())
        //        {
        //            try
        //            {
        //                handler.DynamicInvoke(this, EventArgs.Empty);
        //            }
        //            catch (Exception ex)
        //            {

        //                exceptions.Add(ex);
        //            }
        //        }

        //        if (exceptions.Any())
        //        {
        //            throw new AggregateException(exceptions);
        //        }
        //    }

        //    public static void CreateAndRaiseManually()
        //    {
        //        PubManually p = new PubManually();

        //        p.OnChange += (sender, e)
        //            => Console.WriteLine("Subscriber 1 called");

        //        p.OnChange += (sender, e)
        //             =>
        //         { throw new Exception(); };

        //        p.OnChange += (sender, e)
        //                 => Console.WriteLine("Subscriber 3 called");

        //        try
        //        {
        //            p.Raise();
        //        }
        //        catch (AggregateException ex)
        //        {
        //            Console.WriteLine(ex.InnerExceptions.Count);
        //        }
        //    }
        //}

        #endregion

    }
}
