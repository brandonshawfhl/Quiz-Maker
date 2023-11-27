namespace Quiz_Maker
{
    internal class UserInterface
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
            Console.WriteLine("Please name a question you would like to use on your quiz.");
        }

        public static void PrintEnterQuestionBodyMessage()
        {
            Console.WriteLine("Please type out the whole question as you would like it printed.");
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
