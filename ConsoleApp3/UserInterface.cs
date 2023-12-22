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

        public static List<string> PromptForWrongAnswers()
        {
            bool moreWrongAnswers = true;
            List<string> wrongAnswerList = new List<string>();
            while (moreWrongAnswers)
            {
                Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                string wrongAnswer = Console.ReadLine();
                wrongAnswerList.Add(wrongAnswer);

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to create more wrong answers for this question?");
                Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            }
            return wrongAnswerList;
        }

        public static bool GetMoreQuestions()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Would you like to create another question?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = userInput.Key == Constants.USER_YES_CHOICE;
            return moreQuestions;
        }

        public static bool PromptForSaveQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Would you like a copy of this question?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool saveQuiz = userInput.Key == Constants.USER_YES_CHOICE;
            return saveQuiz;
        }

        public static bool PromptForTakeQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Would you like to take your quiz?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool takeQuiz = userInput.Key == Constants.USER_YES_CHOICE;
            return takeQuiz;
        }
    }
}
