namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswers = new List<QuestionAndAnswers>();
            QuestionAndAnswers userQuestion = new QuestionAndAnswers();
            bool moreQuestions = true;
            UserInterface.PrintWelcomeMessage();
            int quizAction = UserInterface.PromptForQuizAction();

            while (quizAction == Constants.MAKE_CHOICE)
            {
                while (moreQuestions)
                {
                    userQuestion.printQuestion = UserInterface.PromptForQuestion();
                    userQuestion.correctAnswer = UserInterface.PromptForCorrectAnswer();
                    List<string> answerList = new List<string>()
                {
                    userQuestion.correctAnswer
                };
                    answerList = UserInterface.PromptForAnswers(answerList);
                    userQuestion.allAnswers = Logic.GetAnswerArray(answerList);
                    questionAndAnswers.Add(userQuestion);
                    moreQuestions = UserInterface.PromptForMoreQuestions();
                }
            }

            Logic.GetQuizOptions(questionAndAnswers, quizAction);
            Logic.PrintQuestionAndAnswers(questionAndAnswers);

        }
    }

}