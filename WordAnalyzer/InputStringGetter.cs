using System;
using System.Net;

namespace WordAnalyzer
{
    internal static class InputStringGetter
    {
        internal static string GetInputString(string input)
        {
            string text;
            if (IsLocalPath(input))
            {
                text = System.IO.File.ReadAllText(input);
            }
            else
            {
                var client = new WebClient();
                text = client.DownloadString(input);
            }

            return text;
        }

        private static bool IsLocalPath(string path)
        {
            return new Uri(path).IsFile;
        }
    }
}
