using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace ConsoleApplication1
{
    class Program
    {
        static long num_Steps = 10000000;
        static double steps;
        static double[] values;
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int i = 0;
            double x, pi, sum = 0.0;
            steps = 1 / (double)num_Steps;
            for (i = 0; i < num_Steps; i++)
            {
                x = (i + 0.5) * steps;
                sum = sum + 4.0 / (1 + x * x);
            }
            pi = steps * sum;
            Console.WriteLine("Pi Simple = ", pi);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.Write("Enter a key to end");
            Console.ReadKey();
        }
    }

}
