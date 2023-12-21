namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            bool moreQuestions = false;
            bool moreWrongAnswers = false;
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
                } while (moreWrongAnswers);

                questionAndAnswerList.Add(userQuestion);
                moreQuestions = UserInterface.IsMoreQuestions();
            }
            while (moreQuestions);

            bool saveQuiz = UserInterface.IsSaveQuiz();
            bool takeQuiz = UserInterface.IsTakeQuiz();
            do
            {
                foreach (object QuestionAndAnswers in questionAndAnswerList)
                {

                }
                takeQuiz = UserInterface.IsTakeQuiz();
            } while (takeQuiz);


        }
    }

}