namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface.PrintWelcomeMessage();
            string questionWording = Console.ReadLine();
            UserInterface.PrintEnterCorrectAnswerMessage();
            string questionCorrectAnswer = Console.ReadLine();
            UserInterface.PrintEnterIncorrectAnswersMessage();
            List<String> incorrectAnswers = new List<String>();
        }
    }
}