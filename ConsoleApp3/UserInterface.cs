namespace Quiz_Maker
{
    internal class UserInterface
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
            Console.WriteLine("Please enter a question you would like to use on your quiz.");
        }

        public static void PrintEnterCorrectAnswerMessage()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
        }

        public static void PrintEnterIncorrectAnswersMessage()
        {
            Console.WriteLine("Please enter the incorrect answers that will be listed as choices for this question.");
        }
    }
}
