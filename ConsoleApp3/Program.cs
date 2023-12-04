namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            bool userStillNeedsMoreQuestions = true;
            char wantsToCreateMoreWrongAnswers = Constants.USER_YES_CHOICE;
            {
                UserInterface.PrintWelcomeMessage();
                QuestionAndAnswers userQuestion = new QuestionAndAnswers();
                userQuestion.questionWording = Console.ReadLine();
                UserInterface.PrintEnterCorrectAnswerMessage();
                userQuestion.correctAnswerWording = Console.ReadLine();
                UserInterface.PrintEnterWrongAnswersMessage();
                {
                    userQuestion.wrongAnswersList.Add(Console.ReadLine());
                    wantsToCreateMoreWrongAnswers = UserInterface.IsCreateMoreWrongAnswers();
                } while (wantsToCreateMoreWrongAnswers == Constants.USER_YES_CHOICE) ;
                questionAndAnswerList.Add(userQuestion);

            } while (userStillNeedsMoreQuestions) ;
        }
    }

}