using MoreLinq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace WordAnalyzer
{
    internal class CharacterCountAnalyzer
    {
        internal static IEnumerable<string> GetCharacterCounts(string input, bool verbose, string delimiter)
        {
            var counts = new ConcurrentDictionary<char, int>();

            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                word.ForEach(c => counts.AddOrUpdate(c, 1, (id, count) => count + 1));
            }

            foreach (var count in counts.OrderBy(c => c.Key, OrderByDirection.Ascending))
            {
                yield return $"{count.Key}: {count.Value}";
            }
        }
    }
}