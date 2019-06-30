using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace JsonBenchmarks
{
    public class BenchConfig : ManualConfig
    {
        public BenchConfig ()
        {
            Add (Job.Core
                .With (Platform.X64)
                .With (Jit.RyuJit)
            );
            Add (MemoryDiagnoser.Default);
        }
    }
}