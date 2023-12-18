namespace Quiz_Maker
{
    internal class UserInterface
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
            Console.WriteLine("Please type out the whole question as you would like it printed.");
        }

        public static void PrintEnterCorrectAnswerMessage()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
        }

        public static void PrintEnterWrongAnswersMessage()
        {
            Console.WriteLine("Please enter the incorrect answers that will be listed as choices for this question.");
        }

        public static char IsCreateMoreWrongAnswers()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to create more wrong answers for this question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char wantsToCreateMoreWrongAnswers = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsToCreateMoreWrongAnswers;
        }

        public static char IsCreateMoreQuestions()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to create another question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char wantsToCreateMoreQuestions = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsToCreateMoreQuestions;
        }

        public static char IsUserWantsACopy()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like a copy of this question?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char wantsACopy = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsACopy;
        }

        public static char IsUserTakesTheQuiz()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Would you like to take your quiz?({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            char wantsToTakeQuiz = Char.ToUpper(Console.ReadKey(true).KeyChar);
            return wantsToTakeQuiz;
        }
    }
}
