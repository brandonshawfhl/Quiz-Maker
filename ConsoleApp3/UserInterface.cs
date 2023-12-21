namespace Quiz_Maker
{
    internal class UserInterface
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
        }

        public static string PromptForQuestion()
        {
            Console.WriteLine("Please type out the whole question as you would like it printed.");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }

        public static string PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
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
            char saveAnotherQuiz = 'N';
            char upperSaveAnotherQuiz = 'N';
            bool saveQuiz = upperSaveAnotherQuiz == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            saveAnotherQuiz = userInput.KeyChar;
            upperSaveAnotherQuiz = char.ToUpper(upperSaveAnotherQuiz);
            return saveQuiz;
        }

        public static bool IsTakeQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to take your quiz?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char takeAnotherQuiz = 'N';
            char upperTakeAnotherQuiz = 'N';
            bool takeQuiz = upperTakeAnotherQuiz == Constants.USER_YES_CHOICE;
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            takeAnotherQuiz = userInput.KeyChar;
            upperTakeAnotherQuiz = char.ToUpper(takeAnotherQuiz);
            return takeQuiz;
        }
    }
}
