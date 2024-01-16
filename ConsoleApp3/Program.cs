namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<QuizCard> currentQuiz = new List<QuizCard>();
            bool anotherQuiz = true;
            UserInterface.PrintWelcomeMessage();

            while (anotherQuiz)
            {
                QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                if (quizChoice == QuizChoice.QuizOptions.Make)
                {
                    QuizCard currentQuizCard = new QuizCard();
                    int questionNumber = -1;
                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        currentQuizCard.printQuestions = UserInterface.PromptForQuestion();
                        currentQuizCard.correctAnswer = UserInterface.PromptForCorrectAnswer();
                        currentQuizCard.allAnswers = UserInterface.PromptForAnswers(currentQuizCard.correctAnswer);
                        moreQuestions = UserInterface.MoreQuestions();
                        currentQuiz.Add(currentQuizCard);
                    }
                }

                if (quizChoice == QuizChoice.QuizOptions.Load)
                {
                    Logic.LoadQuiz();
                }

                if (quizChoice == QuizChoice.QuizOptions.Save)
                {
                    Logic.SaveQuiz(currentQuiz);
                }

                bool takeQuiz = true;
                while (takeQuiz)
                {
                    takeQuiz = UserInterface.PromptToTakeQuiz();
                    Logic.PrintQuiz(currentQuiz);
                }
            }


        }
    }

}