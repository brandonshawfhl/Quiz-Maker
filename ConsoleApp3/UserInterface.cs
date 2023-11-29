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
    }
}
