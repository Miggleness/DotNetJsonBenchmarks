using System;
using System.Collections.Generic;

namespace JsonBenchmarks
{
    public class Fixtures
    {
        public static readonly SimpleStructure SimpleJsonObject = new SimpleStructure
        {
            value1 = "this is value 1",
            value2 = "and this is value 2"
        };

        public static readonly ComplexStructure ComplexJsonObject = new ComplexStructure
        {
            IntValue = 100,
            LongValue = 999_999_999_999,
            DateTimeOffsetValue = new DateTimeOffset (2020, 01, 01, 0, 0, 0, TimeSpan.FromHours (1)),
            DateTimeValue = new DateTime (2020, 1, 1),
            GuidValue = Guid.NewGuid (),
            IsTrue = true,
            Description = "Nobody ain't got no time for that",
            Records = new List<SimpleStructure>
            {
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
                new SimpleStructure{ value1 = "val 1", value2 = "val 2"},
            }
        };

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
}