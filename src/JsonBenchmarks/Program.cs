using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace JsonBenchmarks
{
    class Program
    {
        static void Main (string[] args)
        {
            BenchmarkRunner.Run<SyncBenchmarks> ();
            BenchmarkRunner.Run<AsyncBenchmarks> ();
        }
    }
}