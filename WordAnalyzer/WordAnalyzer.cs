using CommandLine;
using CommandLine.Text;
using MoreLinq;
using System;

namespace WordAnalyzer
{
    public class Options
    {
        public enum AnalyzeOptions
        {
            LeftHand,
            RightHand,
            QwertyHomeRow,
            CharacterCount,
            OrderByLength,
            OrderByAlphabet,
            OrderReverse,
            ReverseEach
        }

        [Option('r', "read", Required = true,
          HelpText = "Input file or URL to be processed.")]
        public string Input { get; set; }

        [Option('t', "type", Required = true,
          HelpText = "Type of analyzation.")]
        public AnalyzeOptions AnalyzeType { get; set; }

        [Option('d', "delimiter", Required = false,
          HelpText = "Delimiter to split words by.")]
        public string Delimiter { get; set; } = "\r\n";

        [Option('v', "verbose", DefaultValue = false,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('w', "wait", DefaultValue = false,
          HelpText = "Wait for confirm upon completion.")]
        public bool Wait { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    public class WordAnalyzer
    {
        public static void Process(Options options)
        {
            switch (options.AnalyzeType)
            {
                case Options.AnalyzeOptions.LeftHand:
                    var leftHandMatches = WordListCharacterAnalyzer.AnalyzeLeftHand(options.Input, options.Verbose, options.Delimiter);
                    leftHandMatches.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.RightHand:
                    var rightHandMatches = WordListCharacterAnalyzer.AnalyzeRightHand(options.Input, options.Verbose, options.Delimiter);
                    rightHandMatches.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.QwertyHomeRow:
                    var qwertyHomeRowMatches = WordListCharacterAnalyzer.AnalyzeQwertyHomeRow(options.Input, options.Verbose, options.Delimiter);
                    qwertyHomeRowMatches.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.CharacterCount:
                    var characterCounts = CharacterCountAnalyzer.GetCharacterCounts(options.Input, options.Verbose, options.Delimiter);
                    characterCounts.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.OrderByLength:
                    var orderByLengthWords = WordOrderer.OrderByLength(options.Input, options.Verbose, options.Delimiter);
                    orderByLengthWords.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.OrderByAlphabet:
                    var alphabeticalWords = WordOrderer.AlphabeticalOrder(options.Input, options.Verbose, options.Delimiter);
                    alphabeticalWords.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.OrderReverse:
                    var reverseOrder = WordOrderer.Reverse(options.Input, options.Verbose, options.Delimiter);
                    reverseOrder.ForEach(m => Console.WriteLine(m));
                    break;
                case Options.AnalyzeOptions.ReverseEach:
                    var reverseEach= WordOrderer.ReverseEach(options.Input, options.Verbose, options.Delimiter);
                    reverseEach.ForEach(m => Console.WriteLine(m));
                    break;
            }
        }
    }
}
