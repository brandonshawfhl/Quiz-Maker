namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<List<string>> currentQuiz = new List<List<string>>();
            bool anotherQuiz = true;
            UserInterface.PrintWelcomeMessage();

            while (anotherQuiz)
            {
                QuizAction.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                if (quizChoice == QuizAction.QuizOptions.Make)
                {

                    int questionNumber = -1;
                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        List<string> currentQuizCard = new List<string>();
                        QuizQuestion currentQuestion = new QuizQuestion();
                        currentQuestion.questionOutput = UserInterface.PromptForQuestion();
                        CorrectAnswer currentCorrectAnswer = new CorrectAnswer();
                        currentCorrectAnswer.correctAnswerOutput = UserInterface.PromptForCorrectAnswer();
                        IncorrectAnswers currentIncorrectAnswers = new IncorrectAnswers();
                        currentIncorrectAnswers.incorrectAnswersOuput = UserInterface.PromptForAnswers();
                        currentQuiz.Add(currentQuizCard);
                        moreQuestions = UserInterface.PromptForMoreQuestions();
                    }
                }

                if (quizChoice == QuizAction.QuizOptions.Load)
                {
                    Logic.LoadQuiz();
                }

                if (quizChoice == QuizAction.QuizOptions.Save)
                {
                    Logic.SaveQuiz(currentQuiz);
                }


                bool seeQuiz = true;
                while(seeQuiz)
                {
                    seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                    UserInterface.PrintWholeQuiz(currentQuiz);
                }

                bool takeQuiz = true;
                while (takeQuiz)
                {
                    takeQuiz = UserInterface.PromptToTakeQuiz();
                    
                }
            }


        }
    }

}