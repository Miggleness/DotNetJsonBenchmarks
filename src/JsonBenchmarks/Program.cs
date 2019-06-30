using System;
using BenchmarkDotNet.Running;

namespace JsonBenchmarks
{
    class Program
    {
        static void Main (string[] args)
        {
            BenchmarkRunner.Run<StandardBenchmarks> ();

        }
    }
}