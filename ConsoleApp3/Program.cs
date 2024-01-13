namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<QuestionAndAnswers> questionAndAnswers = new List<QuestionAndAnswers>();
            bool moreQuestions = true;
            UserInterface.PrintWelcomeMessage();
            QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

            if (quizChoice == QuizChoice.QuizOptions.Make)
            {
                while (moreQuestions)
                {
                    QuestionAndAnswers userQuestion = new QuestionAndAnswers();
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