using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.TimsyMagnus.ConsoleApp.UtilityServices
{
    public static class Utility
    {
        public static int AstrixCount { get; set; } = 13;
        public static int AstrixPrefixPostFixCount { get; set; } = 5;
        public static char LineSymbol { get; set; } = '*';

        public static void StartAdventChallengeAnswer(string adventChallengeDisplayText)
        {
            LineBreak();
            MessageLineWithPrePostFix(adventChallengeDisplayText);
            InsertMultipleLines(2);
        }

        public static void EndAdventChallengeAnswer()
        {
            InsertMultipleLines(2);
            MessageLineWithPrePostFix(ThankDisplayMessage);
            LineBreak();
        }

        public static void DisplayExceptionToConsole(string exceptionMessage)
        {
            LineBreak(1, 2);
            MessageLineWithPrePostFix("Error: Exception found. See message below for blaming.");
            MessageLineWithPrePostFix(exceptionMessage);
            InsertMultipleLines(2);
            MessageLineWithPrePostFix(SorryDisplayMessage);
            LineBreak();
        }

        private static void MessageLineWithPrePostFix(string message)
        {
            Console.WriteLine($"/{new string(LineSymbol, AstrixPrefixPostFixCount)}\t{message}\t{new string(LineSymbol, AstrixPrefixPostFixCount)}\\");
        }

        private static void LineBreak(int linesAfter = 0, int linesBefore = 0)
        {
            InsertMultipleLines(linesBefore);
            Console.WriteLine(new string(LineSymbol, AstrixCount));
            InsertMultipleLines(linesAfter);
        }

        public static void InsertMultipleLines(int blankLineCount)
        {
            if (blankLineCount <= 0) return;
            Console.Write(new string('\x0A', blankLineCount));
        }

        private static string ThankDisplayMessage { get { return "Challenge Complete, Thank you and continue to support your local Devs! And Devs support your local Charities and Non-Profites!"; } }

        private static string SorryDisplayMessage { get { return "Sorry it broke, maybe you broke it? But Thank you and continue to support your local Devs! And Devs support your local Charities and Non-Profites!"; } }

    }
}
