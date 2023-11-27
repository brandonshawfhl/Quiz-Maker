namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int questionNumber = 0;
            List<Question> questionList = new List<Question>();
            bool userStillNeedsMoreQuestions = true;

            {
            questionNumber += 1;
            UserInterface.PrintWelcomeMessage();
            string questionName = Console.ReadLine();
            UserInterface.PrintEnterQuestionBodyMessage();
            Question userQuestion = new Question();
            questionList.Add(userQuestion);
            UserInterface.PrintEnterCorrectAnswerMessage();
            userQuestion.RightAnswer = Console.ReadLine();
            UserInterface.PrintEnterIncorrectAnswersMessage();
            List<string> incorrectAnswers = new List<string>();
            } while (userStillNeedsMoreQuestions);
        }
    }
}