namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int questionNumber = 0;

            questionNumber += 1;
            UserInterface.PrintWelcomeMessage();
            string questionName = Console.ReadLine();
            UserInterface.PrintEnterQuestionBodyMessage();
            Question question{questionNumber} = new Question();
            UserInterface.PrintEnterCorrectAnswerMessage();
            string questionCorrectAnswer = Console.ReadLine();
            UserInterface.PrintEnterIncorrectAnswersMessage();
            List<String> incorrectAnswers = new List<String>();
        }
    }
}