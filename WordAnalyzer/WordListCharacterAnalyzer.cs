using System;
using System.Collections.Generic;
using System.Linq;

namespace WordAnalyzer
{
    internal class WordListCharacterAnalyzer
    {
        internal static IEnumerable<string> AnalyzeQwertyHomeRow(string input, bool verbose, string delimiter)
        {
            return Analyze(input, verbose, delimiter, CharacterSubsetFuncs.IsQwertyHomeRow);
        }

        internal static IEnumerable<string> AnalyzeLeftHand(string input, bool verbose, string delimiter)
        {
            return Analyze(input, verbose, delimiter, CharacterSubsetFuncs.IsLeftHand);
        }

        internal static IEnumerable<string> AnalyzeRightHand(string input, bool verbose, string delimiter)
        {
            return Analyze(input, verbose, delimiter, CharacterSubsetFuncs.IsRightHand);
        }

        private static IEnumerable<string> Analyze(string input, bool verbose, string delimiter, Func<string, bool> matcher)
        {
            var text = InputStringGetter.GetInputString(input);

            var words = text.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var ret = new List<String>();

            foreach (var word in words)
            {
                if (matcher(word))
                {
                    ret.Add(word);
                }
            }

            return ret;
        }
    }

    internal static class CharacterSubsetFuncs
    {
        internal static bool IsLeftHand(string word)
        {
            const string letters = "qwertasdfgzxcvb";
            return AllLettersIn(word, letters);
        }
        internal static bool IsRightHand(string word)
        {
            const string letters = "yuiophjklnm";
            return AllLettersIn(word, letters);
        }
        internal static bool IsQwertyHomeRow(string word)
        {
            const string letters = "asdfghjkl";
            return AllLettersIn(word, letters);
        }

        private static bool AllLettersIn(string word, string letters)
        {
            if (word.All(w => IsIn(letters, w)))
            {
                return true;
            }
            return false;
        }

        private static bool IsIn(string letters, char c)
        {
            if (letters.Contains(c))
            {
                return true;
            }
            return false;
        }
    }
}
