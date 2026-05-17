using System;
using System.Globalization;
using System.Linq;
using OmniAssert;
using Xunit;

namespace EmojiDotNet.Tests;

public class EmojiUidTests
{
    [Fact]
    public void Generate_WhenLengthIsZero_ThrowsArgumentException()
    {
        Action act = () => EmojiUid.Generate(0);
        act.Throws<ArgumentException>()
            .WithMessage("Invalid length value.");
    }

    [Fact]
    public void Generate_WithNoArguments_ReturnsUidOfDefaultLength()
    {
        var id = EmojiUid.Generate();
        id.Verify().NotToBeNull();
        GetEmojiCount(id).Verify().ToBe(4);
    }

    [Fact]
    public void Generate_WithSpecifiedLength_ReturnsUidOfCorrectLength()
    {
        const int length = 10;
        var id = EmojiUid.Generate(length);
        id.Verify().NotToBeNull();
        GetEmojiCount(id).Verify().ToBe(length);
    }

    [Fact]
    public void Generate_WhenCalledMultipleTimes_ReturnsUniqueUids()
    {
        var ids = Enumerable.Range(0, 100).Select(_ => EmojiUid.Generate()).ToList();
        ids.Verify().NotToBeEmpty();
        ids.Verify().HasUniqueCount(100);
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