using System;
using System.Collections.Generic;
using System.Linq;

namespace WordAnalyzer
{
    internal class WordOrderer
    {
        internal static IEnumerable<string> OrderByLength(string input, bool verbose, string delimiter)
        {
            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words.OrderByDescending(w => w.Length))
            {
                yield return word;
            }
        }

        internal static IEnumerable<string> Reverse(string input, bool verbose, string delimiter)
        {
            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);

            foreach (var word in words)
            {
                yield return word;
            }
        }

        internal static IEnumerable<string> ReverseEach(string input, bool verbose, string delimiter)
        {
            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                yield return Reverse(word);
            }
        }

        private static string Reverse(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        internal static IEnumerable<string> AlphabeticalOrder(string input, bool verbose, string delimiter)
        {
            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words.OrderBy(w => w))
            {
                yield return word;
            }
        }
    }
}