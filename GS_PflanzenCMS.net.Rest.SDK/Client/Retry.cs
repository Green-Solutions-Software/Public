using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class Retry<T>
    {
        public int Count { get; set; }
        public int SleepTime { get; set; }

        protected Func<T> action = null;

        public Retry(Func<T> action)
        {
            this.action = action;
            this.Count = 5;
            this.SleepTime = 1000;
        }

        public T Execute()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                try
                {
                    return this.action();
                }
                catch
                {
                    System.Threading.Thread.Sleep(this.SleepTime);
                    Trace.WriteLine(string.Format("{0}. retry", i+1));
                }
            }

            return this.action();
        }

        public static U Execute<U>(Func<U> action, int count = 5, int sleepTime = 1000)
        {
            return new Retry<U>(action) 
            { 
                Count = count,
                SleepTime = sleepTime
            }.Execute();
        }

    }

    public class Retry : Retry<bool>
    {
        public Retry(Action action)
            : base(() => { action(); return true; })
        {
        }

        public static void ExecuteVoid(Action action, int count = 5)
        {
            new Retry(action) { Count = count }.Execute();
        }
    }
}
