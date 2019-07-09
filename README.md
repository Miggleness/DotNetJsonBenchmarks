# DotNetJsonBenchmarks

The aim of this repository is to show the performance of popular JSON serializers as of .Net Core 3 preview 6. The scope of tests are rather small at the moment with the goal that later we'd have a repeatable load test covering common use cases.

# Results

## Synchronous Tests

```ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.5 (18F132) [Darwin 18.6.0]
Intel Core i5-5287U CPU 2.90GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100-preview6-012264
  [Host] : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT
  Core   : .NET Core 3.0.0-preview6-27804-01 (CoreCLR 4.700.19.30373, CoreFX 4.700.19.30308), 64bit RyuJIT

Job=Core  Jit=RyuJit  Platform=X64
Runtime=Core

```

| Method                                |         Mean |      Error |     StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
| ------------------------------------- | -----------: | ---------: | ---------: | ------: | -----: | ----: | --------: |
| Serialize_DotNetJson_Simple_ToString  |     673.2 ns |   6.629 ns |   6.201 ns |  1.7624 |      - |     - |     288 B |
| Serialize_SpanJson_Simple_ToString    |     236.8 ns |   3.007 ns |   2.812 ns |  0.8810 |      - |     - |     144 B |
| Serialize_Utf8Json_Simple_ToString    |     238.7 ns |   2.070 ns |   1.835 ns |  0.8721 |      - |     - |     144 B |
| Serialize_Newtonsoft_Simple_ToString  |   1,195.2 ns |  29.871 ns |  27.942 ns |  8.7528 |      - |     - |    1432 B |
| Serialize_Jil_Simple_ToString         |     568.0 ns |   1.889 ns |   1.577 ns |  2.9850 |      - |     - |     488 B |
| Serialize_DotNetJson_Simple_ToUtf8    |     599.2 ns |   4.233 ns |   3.752 ns |  1.4191 |      - |     - |     232 B |
| Serialize_SpanJson_Simple_ToUtf8      |     243.2 ns |   2.392 ns |   2.238 ns |  0.5383 |      - |     - |      88 B |
| Serialize_Utf8Json_Simple_ToUtf8      |     177.2 ns |   1.919 ns |   1.795 ns |  0.5295 |      - |     - |      88 B |
| Serialize_DotNetJson_Complex_ToString |  75,089.0 ns | 391.722 ns | 327.106 ns | 58.5938 | 2.9297 |     - |   14688 B |
| Serialize_SpanJson_Complex_ToString   |  20,362.9 ns | 142.084 ns | 132.906 ns | 56.0913 | 2.7771 |     - |   14216 B |
| Serialize_Utf8Json_Complex_ToString   |  21,206.5 ns |  54.386 ns |  42.461 ns | 57.0984 | 2.8381 |     - |   14216 B |
| Serialize_Newtonsoft_Complex_ToString | 123,037.4 ns | 383.480 ns | 358.708 ns | 60.7910 | 5.8594 |     - |   32184 B |
| Serialize_Jil_Complex_ToString        |  46,251.2 ns | 376.913 ns | 334.124 ns | 88.9893 | 7.4463 |     - |   40656 B |
| Serialize_DotNetJson_Complex_ToUtf8   |  71,688.7 ns | 197.496 ns | 175.075 ns | 45.4102 |      - |     - |    7592 B |
| Serialize_SpanJson_Complex_ToUtf8     |  24,962.3 ns | 389.992 ns | 345.718 ns | 43.4570 |      - |     - |    7120 B |
| Serialize_Utf8Json_Complex_ToUtf8     |  19,190.6 ns |  66.990 ns |  59.385 ns | 43.4875 |      - |     - |    7120 B |

## Async Tests using custom MemoryStream

This set of asynchronous tests uses a custom implementation of a memory stream which performs Task.Yield() to force an asynchronous operation.

There is a key difference between `Utf8Json` and `System.Text.Json` when reading from a source stream asynchronously.

`Utf8Json` requests a maximum of 64KB as buffer and reads the entire stream into the buffer. If the allocated buffer capacity isn't enough then it is doubled. This means that if your JSON payload is 75KB in size, all 75KB will be placed in the buffer before it's processed.

`System.Text.Json` on the otherhand requests for a maximum of 16KB for the buffer which is then filled with data read off the stream. The buffered bytes (block) is processed when its capacity is reached or until end of stream. In case the buffer's capacity is reached first, it loops back to reading subsequence data in the stream. If you have an 75KB JSON payload, it will be processed in five 16KB blocks.

The type of benchmark that we have here favors `Utf8Json`. It would be interesting to see how these two compare in realistic use cases. Theoritically, `System.Text.Json` should perform better in reading JSON payload when the connection from the client to the server is iffy or when dealing with very large JSON payload.

| Method                                     |       Mean |     Error |    StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
| ------------------------------------------ | ---------: | --------: | --------: | ------: | -----: | ----: | --------: |
| Serialize_DotNetJson_Simple_AsyncStream    |   4.286 us | 0.0443 us | 0.0370 us |  6.5689 |      - |     - |     744 B |
| Serialize_Utf8Json_Simple_AsyncStream      |   3.455 us | 0.0689 us | 0.0988 us |  5.0468 |      - |     - |     487 B |
| Deserialize_DotNetJson_Complex_AsyncStream | 211.168 us | 0.6998 us | 0.6546 us | 69.5801 | 4.3945 |     - |     736 B |
| Deserialize_Utf8Json_Complex_AsyncStream   | 106.979 us | 1.6497 us | 1.4624 us | 70.9229 | 4.3945 |     - |     496 B |
