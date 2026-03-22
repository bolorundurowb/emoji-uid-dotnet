using System;
using System.Globalization;
using System.Linq;
using AwesomeAssertions;
using Xunit;

namespace EmojiDotNet.Tests;

public class EmojiUidTests
{
    [Fact]
    public void ShouldValidateProvidedLength()
    {
        Action action = () => EmojiUid.Generate(0);
        action.Should().ThrowExactly<ArgumentException>("Invalid length value.");
    }

    [Fact]
    public void ShouldGenerateUidWithDefaultLength()
    {
        var id = EmojiUid.Generate();
        id.Should().NotBeEmpty();
        GetEmojiCount(id).Should().Be(4);
    }

    [Fact]
    public void ShouldGenerateUidWithSpecifiedLength()
    {
        const int length = 10;
        var id = EmojiUid.Generate(length);
        id.Should().NotBeEmpty();
        GetEmojiCount(id).Should().Be(length);
    }

    [Fact]
    public void ShouldGenerateDifferentUids()
    {
        var ids = Enumerable.Range(0, 100).Select(_ => EmojiUid.Generate()).ToList();
        ids.Distinct().Count().Should().Be(100);
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