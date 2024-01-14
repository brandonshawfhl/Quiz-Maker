namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UserInterface.PrintWelcomeMessage();
            QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

            if (quizChoice == QuizChoice.QuizOptions.Make)
            {
                userQuiz madeQuiz = new userQuiz();

                List<string> questionList = new List<string>();
                string printQuestion = UserInterface.PromptForQuestion();
                questionList.Add(printQuestion);
                List<string> answerList = new List<string>();
                List<string> correctAnswersList = new List<string>();
                string correctAnswer = UserInterface.PromptForCorrectAnswer();
                correctAnswersList.Add(correctAnswer);
                madeQuiz.correctAnswers = correctAnswersList();
                answerList = UserInterface.PromptForAnswers(correctAnswer);
                madeQuiz.printQuestions = questionList;
                madeQuiz.allAnswers = answerList;
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