using System;
using System.Globalization;
using System.Linq;
using static OmniAssert.Assert;
using Xunit;

namespace EmojiDotNet.Tests;

public class EmojiUidTests
{
    [Fact]
    public void Generate_WhenLengthIsZero_ThrowsArgumentException()
    {
        Throws<ArgumentException>(() => EmojiUid.Generate(0))
            .WithMessage("Invalid length value.");
    }

    [Fact]
    public void Generate_WithNoArguments_ReturnsUidOfDefaultLength()
    {
        var id = EmojiUid.Generate();
        Verify(id).NotToBeNull();
        Verify(GetEmojiCount(id)).ToBe(4);
    }

    [Fact]
    public void Generate_WithSpecifiedLength_ReturnsUidOfCorrectLength()
    {
        const int length = 10;
        var id = EmojiUid.Generate(length);
        Verify(id).NotToBeNull();
        Verify(GetEmojiCount(id)).ToBe(length);
    }

    [Fact]
    public void Generate_WhenCalledMultipleTimes_ReturnsUniqueUids()
    {
        var ids = Enumerable.Range(0, 100).Select(_ => EmojiUid.Generate()).ToList();
        Verify(ids).NotToBeEmpty();
        Verify(ids).HasUniqueCount(100);
    }

    private static int GetEmojiCount(string text)
    {
        var enumerator = StringInfo.GetTextElementEnumerator(text);
        var count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }
        return count;
    }
}