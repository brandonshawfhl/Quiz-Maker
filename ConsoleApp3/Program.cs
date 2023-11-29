namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswersList = new List<QuestionAndAnswers>();
            bool userStillNeedsMoreQuestions = true;

            {
                UserInterface.PrintWelcomeMessage();
                string questionName = Console.ReadLine();
                QuestionAndAnswers userQuestionAndAnswers = new QuestionAndAnswers();
                questionAndAnswersList.Add(userQuestionAndAnswers);
                UserInterface.PrintEnterCorrectAnswerMessage();
                userQuestionAndAnswers.correctAnswer = Console.ReadLine();
                UserInterface.PrintEnterWrongAnswersMessage();
                List<string> incorrectAnswers = new List<string>();
            } while (userStillNeedsMoreQuestions) ;
        }
    }

}