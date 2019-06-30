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
    public class StandardBenchmarks
    {
        [Benchmark]
        public string Serialize_DotNetJson_Simple_ToString ()
        {
            return NetJS.ToString (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_SpanJson_Simple_ToString ()
        {
            return SpanJS.Serialize (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_Newtonsoft_Simple_ToString ()
        {
            return JsonNet.SerializeObject (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_Jil_Simple_ToString ()
        {
            return JilJS.Serialize (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_DotNetJson_Simple_ToUtf8 ()
        {
            return NetJS.ToUtf8Bytes (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_SpanJson_Simple_ToUtf8 ()
        {
            return SpanJS8.Serialize (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_Utf8Json_Simple_ToUtf8 ()
        {
            return Utf8Json.JsonSerializer.Serialize (Fixtures.SimpleJsonObject);
        }

        [Benchmark]
        public string Serialize_DotNetJson_Complex_ToString ()
        {
            return NetJS.ToString (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_SpanJson_Complex_ToString ()
        {
            return SpanJS.Serialize (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_Newtonsoft_Complex_ToString ()
        {
            return JsonNet.SerializeObject (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public string Serialize_Jil_Complex_ToString ()
        {
            return JilJS.Serialize (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_DotNetJson_Complex_ToUtf8 ()
        {
            return NetJS.ToUtf8Bytes (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_SpanJson_Complex_ToUtf8 ()
        {
            return SpanJS8.Serialize (Fixtures.ComplexJsonObject);
        }

        [Benchmark]
        public byte[] Serialize_Utf8Json_Complex_ToUtf8 ()
        {
            return Utf8Json.JsonSerializer.Serialize (Fixtures.ComplexJsonObject);
        }
    }
}