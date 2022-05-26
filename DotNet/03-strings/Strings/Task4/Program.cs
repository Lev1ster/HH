using System;
using System.Text;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100000;

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            stopWatch.Reset();

            string elapsedTime = String.Format("{0}",
            ts.Milliseconds);
            Console.WriteLine("String: " + elapsedTime);

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}",
            ts.Milliseconds);
            Console.WriteLine("StringBuilder: " + elapsedTime); 
        }
    }
}
