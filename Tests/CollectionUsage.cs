﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Encryption;
using Xunit;
using Xunit.Abstractions;

public class CollectionUsage: TestBase
{
    public CollectionUsage(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void ByteArrayList()
    {
        var target = new ClassWithByteArrayList
        {
            Property = new List<byte[]>
            {
                new byte[] {2, 3},
                new byte[] {5, 6}
            }
        };
        var result = RoundTrip.Run(target);
        Assert.Equal(new byte[] {5, 6}, result.Property[1]);
    }

    public class ClassWithByteArrayList
    {
        [Encrypt]
        public List<byte[]> Property { get; set; }
    }

    [Fact]
    public void StringList()
    {
        var target = new ClassWithStringList
        {
            Property = new List<string>
            {
                "Value1",
                "Value2"
            }
        };
        var result = RoundTrip.Run(target);
        Assert.Equal("Value2", result.Property[1]);
    }

    public class ClassWithStringList
    {
        [Encrypt]
        public List<string> Property { get; set; }
    }

    [Fact]
    public void StringCollection()
    {
        var target = new ClassWithStringCollection
        {
            Property = new List<string>
            {
                "Value1",
                "Value2"
            }
        };
        var result = RoundTrip.Run(target);
        Assert.Equal("Value2", result.Property.Last());
    }

    public class ClassWithStringCollection
    {
        [Encrypt]
        public ICollection<string> Property { get; set; }
    }

    [Fact]
    public void StringEnumerable()
    {
        var target = new ClassWithStringEnumerable
        {
            Property = new List<string>
            {
                "Value1",
                "Value2"
            }
        };
        var result = RoundTrip.Run(target);
        Assert.Equal("Value2", result.Property.Last());
    }

    public class ClassWithStringEnumerable
    {
        [Encrypt]
        public IEnumerable<string> Property { get; set; }
    }

    [Fact]
    public void GuidEnumerable()
    {
        var target = new ClassWithGuidEnumerable
        {
            Property = new List<Guid>
            {
                new Guid("45b14050-065c-4be7-8bb8-f3b46b8d94e6"),
                new Guid("74b69ad1-f9e8-4549-8524-cce4a8b4c38b")
            }
        };
        var result = RoundTrip.Run(target);
        Assert.Equal("74b69ad1-f9e8-4549-8524-cce4a8b4c38b", result.Property.Last().ToString());
    }

    public class ClassWithGuidEnumerable
    {
        [Encrypt]
        public IEnumerable<Guid> Property { get; set; }
    }
}