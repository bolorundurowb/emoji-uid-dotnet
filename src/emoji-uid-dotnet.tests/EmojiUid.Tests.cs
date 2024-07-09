using System;
using FluentAssertions;
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
    }

    [Fact]
    public void ShouldGenerateUidWithSpecifiedLength()
    {
        const int length = 10;
        var id = EmojiUid.Generate(length);
        id.Should().NotBeEmpty();
    }
}