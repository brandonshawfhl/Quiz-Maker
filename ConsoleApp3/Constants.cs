﻿namespace Quiz_Maker
{
    internal class Constants
    {
        public const ConsoleKey USER_YES_CHOICE = ConsoleKey.Y;
        public const int CHOICE_LIMIT = 10;
        public static readonly List<string> ANSWER_CHOICES = new()
            {
            "A.",
            "B.",
            "C.",
            "D.",
            "E.",
            "F.",
            "G.",
            "H.",
            "I.",
            "J."
            };

        public static readonly List<ConsoleKey> ANSWER_KEYS = new()
       {
           ConsoleKey.A,
           ConsoleKey.B,
           ConsoleKey.C,
           ConsoleKey.D,
           ConsoleKey.E,
           ConsoleKey.F,
           ConsoleKey.G,
           ConsoleKey.H,
           ConsoleKey.I,
           ConsoleKey.J
       };

        public const string PATH = @"..\currentQuiz.xml";
    }
}
