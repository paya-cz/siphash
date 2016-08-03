# SipHash (C#)
SipHash PRF implementation in C#, heavily optimized towards speed. This code is in public domain, free for anyone to use.

[SipHash](https://131002.net/siphash/) is a very fast pseudo-random function, producing 64-bit output using 128-bit key. SipHash is very fast on 64-bit CPUs.

# Benchmark #
Below are the results of a benchmark I ran on i7 3630QM.

64-bit mode (processing 10 GiB in 4 KiB chunks):
- SipHash: 1 226 MiB/s

32-bit mode (processing 10 GiB in 4 KiB chunks):
- SipHash: 324 MiB/s