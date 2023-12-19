namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            char moreQuestions = Constants.USER_YES_CHOICE;
            char moreWrongAnswers = Constants.USER_YES_CHOICE;
            UserInterface.PrintWelcomeMessage();

            do
            {
                QuestionAndAnswers userQuestion = new QuestionAndAnswers();
                userQuestion.questionWording = Console.ReadLine();
                UserInterface.PrintEnterCorrectAnswerMessage();

                userQuestion.correctAnswerWording = Console.ReadLine();
                do
                {
                    UserInterface.PrintEnterWrongAnswersMessage();
                    userQuestion.wrongAnswersList.Add(Console.ReadLine());
                    moreWrongAnswers = UserInterface.IsMoreWrongAnswers();
                } while (moreWrongAnswers == Constants.USER_YES_CHOICE);

                questionAndAnswerList.Add(userQuestion);
                moreQuestions = UserInterface.IsMoreQuestions();
            }
            while (moreQuestions == Constants.USER_YES_CHOICE);

            char saveQuizCopy = UserInterface.IsCopyQuiz();

            char takeQuiz = Constants.USER_YES_CHOICE;
            do
            {
                foreach (object QuestionAndAnswers in questionAndAnswerList)
                {

                }
                takeQuiz = UserInterface.IsTakeQuiz();
            } while (takeQuiz == Constants.USER_YES_CHOICE);


        }
    }

}