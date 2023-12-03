namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questionList = new List<Question>();
            List<CorrectAnswer> correctAnswersList = new List<CorrectAnswer>();
            bool userStillNeedsMoreQuestions = true;
            char wantsToCreateMoreWrongAnswers = Constants.USER_YES_CHOICE;
            {
                UserInterface.PrintWelcomeMessage();
                Question userQuestion = new Question();
                userQuestion.questionWording = Console.ReadLine();
                questionList.Add(userQuestion);
                UserInterface.PrintEnterCorrectAnswerMessage();
                CorrectAnswer userQuestionCorrectAnswer = new CorrectAnswer();
                userQuestionCorrectAnswer.correctAnswerWording = Console.ReadLine();
                correctAnswersList.Add(userQuestionCorrectAnswer);
                UserInterface.PrintEnterWrongAnswersMessage();
                char userWantsToCreateMoreWrongAnswers = Constants.USER_YES_CHOICE;
                {
                    WrongAnswers.wrongAnswersList.Add(Console.ReadLine());
                    questionAndAnswersList.Add(userQuestionAndAnswers);
                    userWantsToCreateMoreWrongAnswers = UserInterface.IsCreateMoreWrongAnswers();
                } while (wantsToCreateMoreWrongAnswers == Constants.USER_YES_CHOICE) ;
            } while (userStillNeedsMoreQuestions) ;
        }
    }

}