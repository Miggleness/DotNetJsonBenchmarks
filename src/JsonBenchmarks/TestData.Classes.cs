using System;
using System.Collections.Generic;

namespace JsonBenchmarks
{
    public class SimpleStructure
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class ComplexStructure
    {
        public int IntValue { get; set; }
        public long LongValue { get; set; }
        public DateTimeOffset DateTimeOffsetValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public Guid GuidValue { get; set; }
        public bool IsTrue { get; set; }
        public string Description { get; set; }
        public List<SimpleStructure> Records { get; set; }
    }
}