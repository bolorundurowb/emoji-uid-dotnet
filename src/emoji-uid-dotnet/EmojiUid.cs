using System;
using System.Text;

namespace EmojiDotNet;

public static class EmojiUid
{
    // ReSharper disable once InconsistentNaming
    private static readonly Random _random = new();

    /// <summary>
    /// Generates a unique identifier composed of random emojis.
    /// </summary>
    /// <param name="length">
    /// The length of the emoji-based unique identifier. The default value is 4.
    /// The length must be greater than 0, otherwise an exception will be thrown.
    /// </param>
    /// <returns>
    /// A string containing a sequence of random emojis with the specified length.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the provided length is less than 1.
    /// </exception>
    public static string Generate(int length = 4)
    {
        if (length < 1)
            throw new ArgumentException("Invalid length value.");

        var builder = new StringBuilder();

        for (var i = 0; i < length; i++)
            builder.Append(GetEmoji());

        return builder.ToString();
    }

    private static string GetEmoji()
    {
        var emojis = Resources.Emojis[_random.Next(Resources.Emojis.Count)];
        return emojis[_random.Next(emojis.Count)];
    }
}
