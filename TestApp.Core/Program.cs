using System;

namespace TestApp.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Run benchmarks
            SipHash.Benchmarks.Benchmark.Run(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}