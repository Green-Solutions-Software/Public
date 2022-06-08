using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Classes
{
    public class Retry<T>
    {
        public int Count { get; set; }
        public int SleepTime { get; set; }

        protected Func<Task<T>> action = null;

        public Retry(Func<Task<T>> action, int count = 5)
        {
            this.action = action;
            this.Count = count;
            this.SleepTime = 1000;
        }

        public async Task<T> Execute()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                try
                {
                    return await this.action();
                }
                catch(Exception e)
                {
                    await Task.Delay(this.SleepTime);
                }
            }

            return await this.action();
        }

        public static async Task<U> Execute<U>(Func<Task<U>> action, int count = 5, int sleepTime = 1000)
        {
            return await new Retry<U>(action)
            {
                Count = count,
                SleepTime = sleepTime
            }.Execute();
        }

    }

    public class Retry : Retry<bool>
    {
        public Retry(Func<Task> action, int count = 5)
            : base(async () => 
            {
                await action(); return true;
            }, count)
        {
        }

    }
}
