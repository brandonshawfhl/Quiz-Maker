namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<string> printQuestions = new List<string>();
            bool moreQuestions = true;
            UserInterface.PrintWelcomeMessage();
            QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

            if (quizChoice == QuizChoice.QuizOptions.Make)
            {

                while (moreQuestions)
                {
                    List<string> questionList = new List<string>();
                    string printQuestion = UserInterface.PromptForQuestion();
                    questionList.Add(printQuestion);
                    List<string> answerList = new List<string>();
                    List<string> correctAnswerList = new List<string>();
                    string correctAnswer = UserInterface.PromptForCorrectAnswer();
                    answerList = UserInterface.PromptForAnswers(correctAnswer);
                    moreQuestions = UserInterface.PromptForMoreQuestions();
                }
            }

            if (quizChoice == QuizChoice.QuizOptions.Load)
            {
                Logic.LoadQuiz(questionAndAnswers);
            }

            if (quizChoice == QuizChoice.QuizOptions.Save)
            {
                Logic.SaveQuiz(questionAndAnswers);
            }

            Logic.PrintQuestionAndAnswers(questionAndAnswers);

        }
    }

}