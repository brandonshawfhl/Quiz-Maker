namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            bool moreQuestions = true;
            bool moreWrongAnswers = true;
            UserInterface.PrintWelcomeMessage();

            do
            {
                QuestionAndAnswers userQuestion = new QuestionAndAnswers();
                userQuestion.questionWording = UserInterface.PromptForQuestion();
                userQuestion.correctAnswerWording = UserInterface.PromptForCorrectAnswer();

                userQuestion.correctAnswerWording = Console.ReadLine();
                do
                {
                    UserInterface.PromptForWrongAnswers();
                    userQuestion.wrongAnswersList.Add(Console.ReadLine());
                    moreWrongAnswers = UserInterface.GetMoreWrongAnswers();
                } while (moreWrongAnswers);

                questionAndAnswerList.Add(userQuestion);
                moreQuestions = UserInterface.GetMoreQuestions();
            }
            while (moreQuestions);

            bool saveQuiz = UserInterface.IsSaveQuiz();
            bool takeQuiz = true;
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