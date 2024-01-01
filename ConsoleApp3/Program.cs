namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {

            List<QuestionAndAnswers> questionAndAnswersList = new List<QuestionAndAnswers>();
            QuestionAndAnswers userQuestion = new QuestionAndAnswers();
            bool moreQuestions = true;
            UserInterface.PrintWelcomeMessage();

            while (moreQuestions)
            {
                userQuestion.printQuestion = UserInterface.PromptForQuestion();
                userQuestion.rightAnswer = UserInterface.PromptForCorrectAnswer();
                userQuestion.wrongAnswers = UserInterface.PromptForWrongAnswers();

                questionAndAnswersList.Add(userQuestion);
                moreQuestions = UserInterface.PromptForMoreQuestions();
            }

            Logic.PromptUserInterface.PromptForQuizAction();
           F


        }
    }

}