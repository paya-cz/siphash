using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace TestApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Run tests
            new SipHash.Tests.SipHashTest().TestBattery();

            // JIT
            BenchmarkSipHash(1, 1, false);
            // Real benchmark - digest 4 KiB 2 621 440 times (10 GiB of data)
            BenchmarkSipHash(2621440, 4 * 1024, true);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void BenchmarkSipHash(int iterations, int length, bool log)
        {
            // Get random key
            var key = GetRandomBytes(16);
            // Get specified amount of random data
            var data = GetRandomBytes(length);
            // Initialize SipHash engine
            var siphash = new SipHash.SipHash(key);

            // Benchmark
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                siphash.Compute(data, 0, data.Length);
            var elapsed = stopWatch.Elapsed;

            if (log)
            {
                Console.WriteLine("SipHash benchmark results:");
                Console.WriteLine("- Elapsed: {0}", elapsed.ToString(@"hh\:mm\:ss\.fff"));
                Console.WriteLine("- Digested {0} bytes ({1} KiB) {2} times", data.Length, (data.Length / 1024d).ToString("N2"), iterations);
                Console.WriteLine("- Speed: {0} MiB/s", (data.Length / 1024d / 1024d / elapsed.TotalSeconds * iterations).ToString("N2"));
            }
        }

        private static byte[] GetRandomBytes(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Number of bytes cannot be negative.");

            var bytes = new byte[count];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(bytes);
            return bytes;
        }
    }
}
