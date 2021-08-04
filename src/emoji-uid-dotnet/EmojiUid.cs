using System;
using System.Text;

namespace emoji_dotnet
{
    public static class EmojiUid
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Random _random = new Random();

        public static string Generate(int length = 5)
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