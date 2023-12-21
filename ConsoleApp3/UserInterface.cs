﻿namespace Quiz_Maker
{
    internal class UserInterface
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
            Console.WriteLine("Please type out the whole question as you would like it printed.");
        }

        public static void PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
        }

        public static void PromptForWrongAnswers()
        {
            Console.WriteLine("Please enter the incorrect answers that will be listed as choices for this question.");
        }

        public static bool GetMoreWrongAnswers()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to create more wrong answers for this question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char anotherWrongAnswer = 'N';
            char upperAnotherWrongAnswer = 'N';
            bool moreWrongAnswers = upperAnotherWrongAnswer == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            anotherWrongAnswer = userInput.KeyChar;
            return moreWrongAnswers;
        }

        public static bool GetMoreQuestions()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to create another question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char anotherQuestion = 'N';
            char upperAnotherQuestion = 'N';
            bool moreQuestions = upperAnotherQuestion == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            anotherQuestion = userInput.KeyChar;
            upperAnotherQuestion = char.ToUpper(anotherQuestion);
            return moreQuestions;
        }

        public static bool IsSaveQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like a copy of this question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char userInputSaveQuiz = 'N';
            char upperUserInputSaveQuiz = 'N';
            bool saveQuiz = upperUserInputSaveQuiz == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            userInputSaveQuiz = userInput.KeyChar;
            upperUserInputSaveQuiz = char.ToUpper(upperUserInputSaveQuiz);
            return saveQuiz;
        }

        public static bool IsTakeQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to take your quiz?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char userInputTakeQuiz = 'N';
            char upperUserInputTakeQuiz = 'N';
            bool takeQuiz = upperUserInputTakeQuiz == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            userInputTakeQuiz = userInput.KeyChar;
            upperUserInputTakeQuiz = char.ToUpper(userInputTakeQuiz);
            return takeQuiz;
        }
    }
}
