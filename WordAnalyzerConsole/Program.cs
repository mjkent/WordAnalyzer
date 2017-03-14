using System;
using WordAnalyzer;

namespace WordAnalyzerConsole
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.Verbose)
                {
                    Console.WriteLine("Analyzing Filename: {0}", options.Input);
                }
                WordAnalyzer.WordAnalyzer.Process(options);

                if (options.Wait)
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
