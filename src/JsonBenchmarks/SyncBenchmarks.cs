using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

using NetJS = System.Text.Json.Serialization.JsonSerializer;
using SpanJS = SpanJson.JsonSerializer.Generic.Utf16;
using SpanJS8 = SpanJson.JsonSerializer.Generic.Utf8;
using JsonNet = Newtonsoft.Json.JsonConvert;
using JilJS = Jil.JSON;

namespace JsonBenchmarks
{
    [Config (typeof (BenchConfig))]
    public class SyncBenchmarks
    {
        [Benchmark]
        public string Serialize_DotNetJson_Simple_ToString ()
        {
            return NetJS.ToString (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_SpanJson_Simple_ToString ()
        {
            return SpanJS.Serialize (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_Utf8Json_Simple_ToString ()
        {
            return Utf8Json.JsonSerializer.ToJsonString (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_Newtonsoft_Simple_ToString ()
        {
            return JsonNet.SerializeObject (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_Jil_Simple_ToString ()
        {
            return JilJS.Serialize (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_DotNetJson_Simple_ToUtf8 ()
        {
            return NetJS.ToUtf8Bytes (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_SpanJson_Simple_ToUtf8 ()
        {
            return SpanJS8.Serialize (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_Utf8Json_Simple_ToUtf8 ()
        {
            return Utf8Json.JsonSerializer.Serialize (TestData.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_DotNetJson_Complex_ToString ()
        {
            return NetJS.ToString (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_SpanJson_Complex_ToString ()
        {
            return SpanJS.Serialize (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_Utf8Json_Complex_ToString ()
        {
            return Utf8Json.JsonSerializer.ToJsonString (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_Newtonsoft_Complex_ToString ()
        {
            return JsonNet.SerializeObject (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_Jil_Complex_ToString ()
        {
            return JilJS.Serialize (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_DotNetJson_Complex_ToUtf8 ()
        {
            return NetJS.ToUtf8Bytes (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_SpanJson_Complex_ToUtf8 ()
        {
            return SpanJS8.Serialize (TestData.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_Utf8Json_Complex_ToUtf8 ()
        {
            return Utf8Json.JsonSerializer.Serialize (TestData.ComplexJsonObject);
        }
    }
}