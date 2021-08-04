using System;
using System.Text;

namespace emoji_dotnet
{
    public static class EmojiUid
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates a random emoji string of a specified length.
        /// </summary>
        /// <param name="length">Minimum length of the generated id.</param>
        /// <returns>The generated emoji uid.</returns>
        /// <exception cref="ArgumentException">Thrown when length is less than 1.</exception>
        public static string Generate(int length = 3)
        {
            if (length < 1)
                throw new ArgumentException("Invalid length value.");

            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(GetEmoji());
            }

            return builder.ToString();
        }

        private static string GetEmoji()
        {
            var emojis = Resources.Emojis[_random.Next(Resources.Emojis.Count)];
            return emojis[_random.Next(emojis.Count)];
        }
    }
}