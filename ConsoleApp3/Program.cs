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
                questionAndAnswerList.Add(userQuestion);
                char userWantsToCreateMoreWrongAnswers = Constants.USER_YES_CHOICE;
                {
                    userQuestion.wrongAnswersList.Add(Console.ReadLine());
                    userWantsToCreateMoreWrongAnswers = UserInterface.IsCreateMoreWrongAnswers();
                } while (wantsToCreateMoreWrongAnswers == Constants.USER_YES_CHOICE) ;

            } while (userStillNeedsMoreQuestions) ;
        }
    }

}