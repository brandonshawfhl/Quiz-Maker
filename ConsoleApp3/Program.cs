namespace Quiz_Maker
{
    internal class Program
    {
        enum QuizAnswers
        {
            CorrectAnswer,
            WrongAnswers
        }

        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswerList = new List<QuestionAndAnswers>();
            bool moreQuestions = true;
            UserInterface.PrintWelcomeMessage();

            while (moreQuestions)
            {
                QuestionAndAnswers userQuestion = new QuestionAndAnswers();
                userQuestion.questionWording = UserInterface.PromptForQuestion();
                userQuestion.correctAnswer = UserInterface.PromptForCorrectAnswer();
                userQuestion.wrongAnswersList = UserInterface.PromptForWrongAnswers();

                questionAndAnswerList.Add(userQuestion);
                moreQuestions = UserInterface.PromptForMoreQuestions();
            }

            bool saveQuiz = UserInterface.PromptForQuizAction();
            bool takeQuiz = true;
            do
            {
                foreach (object QuestionAndAnswers in questionAndAnswerList)
                {

                }
                takeQuiz = UserInterface.PromptForTakeQuiz();
            } while (takeQuiz);


        }
    }

}