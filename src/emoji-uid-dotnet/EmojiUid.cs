using System;
using System.Text;
using System.Threading;

namespace EmojiDotNet;

public static class EmojiUid
{
    private static int _seed = Environment.TickCount;

    private static readonly ThreadLocal<Random> Random =
        new(() => new Random(Interlocked.Increment(ref _seed)));

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

        var emojis = Resources.Emojis;
        var emojisLength = emojis.Length;

        var rng = Random.Value!;
        // UTF-16 length varies (surrogates, ZWJ); capacity avoids most reallocations.
        var builder = new StringBuilder(length * 24);

        for (var i = 0; i < length; i++)
            builder.Append(emojis[rng.Next(emojisLength)]);

        return builder.ToString();
    }
}
