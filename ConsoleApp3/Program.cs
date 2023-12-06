namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            char userStillNeedsMoreQuestions = Constants.USER_YES_CHOICE;
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
                userStillNeedsMoreQuestions = UserInterface.IsCreateMoreQuestions();
            } while (userStillNeedsMoreQuestions == Constants.USER_YES_CHOICE) ;

            char userWantsACopy = UserInterface.IsUserWantsACopy();

            char userTakesTheQuiz = Constants.USER_YES_CHOICE;
            {
                userTakesTheQuiz = UserInterface.IsUserTakesTheQuiz();
            } while (userTakesTheQuiz == Constants.USER_YES_CHOICE) ;

            
        }
    }

}