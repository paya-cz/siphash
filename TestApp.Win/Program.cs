using System;

namespace TestApp.Win
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Run tests
            new SipHash.Tests.SipHashTest().TestBattery();

            // Run benchmarks
            SipHash.Benchmarks.Benchmark.Run(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
