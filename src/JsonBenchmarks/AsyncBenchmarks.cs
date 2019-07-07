using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using NetJS = System.Text.Json.Serialization.JsonSerializer;
using SpanJS = SpanJson.JsonSerializer.Generic.Utf16;
using SpanJS8 = SpanJson.JsonSerializer.Generic.Utf8;
using JsonNet = Newtonsoft.Json.JsonConvert;
using JilJS = Jil.JSON;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonBenchmarks
{
    [Config (typeof (BenchConfig))]
    public class AsyncBenchmarks
    {
        Stream ComplexDataStreamUtf8;
        Stream ComplexDataStreamUtf16;

        [GlobalSetup]
        public void Setup ()
        {
            var bytes = Encoding.UTF8.GetBytes (TestData.ComplexDataString);
            ComplexDataStreamUtf8 = new MemoryStreamForcedAsync (bytes);

            bytes = Encoding.Unicode.GetBytes (TestData.ComplexDataString);
            ComplexDataStreamUtf16 = new MemoryStreamForcedAsync (bytes);
        }

        [Benchmark]
        public async Task Serialize_DotNetJson_Simple_AsyncStream ()
        {
            var stream = new MemoryStreamForcedAsync ();
            await NetJS.WriteAsync (TestData.SimpleJsonObject, TestData.SimpleJsonObject.GetType (), stream);
        }

        [Benchmark]
        public async Task Serialize_Utf8Json_Simple_AsyncStream ()
        {
            var stream = new MemoryStreamForcedAsync ();
            await Utf8Json.JsonSerializer.SerializeAsync (stream, TestData.SimpleJsonObject);
        }

        [Benchmark]
        public async Task Deserialize_DotNetJson_Complex_AsyncStream ()
        {
            ComplexDataStreamUtf8.Position = 0;
            await NetJS.ReadAsync (ComplexDataStreamUtf8, TestData.ComplexJsonObject.GetType ());
        }

        [Benchmark]
        public async Task Deserialize_Utf8Json_Complex_AsyncStream ()
        {
            ComplexDataStreamUtf8.Position = 0;
            await Utf8Json.JsonSerializer.DeserializeAsync<ComplexStructure> (ComplexDataStreamUtf8);
        }
    }
}