using System;
using System.Threading.Tasks;

namespace RateLimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            var limiter = new RateLimiterClass(10, TimeSpan.FromSeconds(5));

            var t = Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    if(!limiter.Process("App1"))
                    {
                        //Task.Delay(1).Wait();
                        Console.WriteLine("App1 - Rejected");
                        break;
                    } else
                    {
                        Console.WriteLine("App1 - Accepted");
                    }
                }
            });

           

            var t1 = Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    if (!limiter.Process("App2"))
                    {
                        //Task.Delay(1).Wait();
                        Console.WriteLine("App2 - Rejected");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("App2 - Accepted");
                    }
                }
            });

            Task.WaitAll(t,t1);

            Console.ReadKey();
        }
    }
}
