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

            // JIT + heat up the CPU
            BenchmarkSipHash(2621440, 4 * 1024, false);
            // Real benchmark - digest 4 KiB 2 621 440 times (10 GiB of data)
            BenchmarkSipHash(2621440, 4 * 1024, true);
            // And 7 bytes 153391689 times (1 GiB of data)
            BenchmarkSipHash(153391689, 7, true);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void BenchmarkSipHash(int iterations, int length, bool showOutput)
        {
            // Initialize SipHash engine with a random key
            var siphash = new SipHash.SipHash(GetRandomBytes(16));
            
            // Generate specified amount of random data
            var data = GetRandomBytes(length);

            // Benchmark
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                siphash.Compute(data, 0, data.Length);
            var elapsed = stopWatch.Elapsed;

            if (showOutput)
            {
                Console.WriteLine("SipHash benchmark results:");
                Console.WriteLine("- Digested {0} {1} times", BytesToString(data.Length), iterations);
                Console.WriteLine("- Elapsed: {0}", elapsed.ToString(@"hh\:mm\:ss\.fff"));
                Console.WriteLine("- Speed: {0}/s", BytesToString(data.Length / elapsed.TotalSeconds * iterations));
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

        private static string BytesToString(double bytes)
        {
            if (bytes < 1024)
                return bytes.ToString("N0") + " B";

            var KiB = bytes / 1024d;
            if (KiB < 1024)
                return KiB.ToString("N1") + " KiB";

            var MiB = KiB / 1024d;
            return MiB.ToString("N1") + " MiB";
        }
    }
}
