using System;
using System.Net;

namespace WordAnalyzer
{
    internal static class InputStringGetter
    {
        internal static string GetInputString(string input)
        {
            if (IsLocalPath(input))
            {
                return System.IO.File.ReadAllText(input);
            }
            else
            {
                var client = new WebClient();
                return client.DownloadString(input);
            }
        }

        private static bool IsLocalPath(string path)
        {
            return new Uri(path).IsFile;
        }
    }
}
