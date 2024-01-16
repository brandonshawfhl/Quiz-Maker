namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            bool anotherQuiz = true;
            UserInterface.PrintWelcomeMessage();
            while (anotherQuiz)
            {
                QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();
                List<QuizCard> currentQuiz = new List<QuizCard>();

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
                    }
                }

                if (quizChoice == QuizChoice.QuizOptions.Load)
                {
                    Logic.LoadQuiz();
                }

                if (quizChoice == QuizChoice.QuizOptions.Save)
                {
                    Logic.SaveQuiz(madeQuiz);
                }
            }



            Logic.PrintQuiz(currentQuiz);




        }
    }

}