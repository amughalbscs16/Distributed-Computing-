using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace ConsoleApplication1
{
    public class ThreadPi
    {
        private double x, steps, sum = 0,pi;
        private int start_i, end_i;

        public ThreadPi(int start_i, int end_i, double steps)
        {
            this.start_i = start_i;
            this.end_i = end_i;
            this.steps = steps;
        }

        public void ThreadFunction()
        {
            for (int i=start_i;i<end_i;i++)
            {
                x = (i + 0.5) * steps;
                sum = sum + 4.0 / (1 + x * x);
            }
            pi = steps * sum;
        }

        public double getSum()
        {
            return sum;
        }
        public double getPi()
        {
            return pi;
        }
    }

    class Program
    {
        static long num_Steps = 10000000;
        static double steps, final_pi = 0.0;
        static double[] values = new double[10];
        static ThreadPi[] threadObjs = new ThreadPi[10];
        static Thread[] threads = new Thread[10];
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int i = 0;
            double x, pi, sum = 0.0;
            steps = 1 / (double)num_Steps;
            for (i=0;i<threadObjs.Length;i++)
            {
                threadObjs[i] = new ThreadPi((Convert.ToInt32(num_Steps / 10) * i), Convert.ToInt32((num_Steps / 10) * (i + 1)), steps);
                threads[i] = new Thread(new ThreadStart(threadObjs[i].ThreadFunction));
                threads[i].Start();
                threads[i].Join();
            }
            for (i = 0; i < threadObjs.Length; i++)
            {
                final_pi += threadObjs[i].getPi();
            }
            Console.WriteLine("Final Pi = " + final_pi);

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


