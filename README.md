# SipHash (C#)
SipHash PRF implementation in C#, heavily optimized towards speed. This code is in public domain, free for anyone to use.

[SipHash](https://131002.net/siphash/) is a very fast pseudo-random function, producing 64-bit output using 128-bit key. SipHash is very fast on 64-bit CPUs.

# Benchmarks #
Below are the results of a benchmark (processing 10 GiB in 4 KiB chunks) I ran on laptop i7 3630QM (Turbo Boost enabled) on Win8.1:

| Runtime         |  Mode  |       Speed |
| --------------- |:------:| -----------:|
| .NET 4.6.1      | 64 bit | 1 226 MiB/s |
| .NET 4.6.1      | 32 bit |   324 MiB/s |
| .NET Core RC 2  | 64 bit | 1 940 MiB/s |
| .NET Core RC 2  | 32 bit |   324 MiB/s |

Please note that 64-bit .NET Core Preview 2 JIT [supports bit rotation idioms](https://github.com/dotnet/coreclr/issues/1619), while the 32-bit .NET Core JIT and the full .NET framework JITs still translate rotations into a series of SHIFTs, MOV and OR instructions (which is the reason for massive performance difference).