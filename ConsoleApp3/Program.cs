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
                QuizAction.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                if (quizChoice == QuizAction.QuizOptions.Make)
                {

                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new QuizCard();
                        currentQuizCard.questionOutput = UserInterface.PromptForQuestion();
                        currentQuizCard.correctAnswer = UserInterface.PromptForCorrectAnswer();
                        currentQuizCard.incorrectAnswers = UserInterface.PromptForAnswers();
                        currentQuiz.Add(currentQuizCard);
                        moreQuestions = UserInterface.PromptForMoreQuestions();
                        UserInterface.ConsoleClear();
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

                bool seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                UserInterface.ConsoleClear();
                if (seeQuiz)
                {
                    UserInterface.PrintWholeQuiz(currentQuiz);
                }

                bool takeQuiz = UserInterface.PromptToTakeQuiz();
                if (takeQuiz)
                {
                    List<bool> rightOrWrong = Logic.GetScoringList(currentQuiz);
                    for (int questionNumber = 1; questionNumber <= currentQuiz.Count; questionNumber++)
                    {
                        bool rightAnswer = UserInterface.PromptToAnswerQuizQuestion(currentQuiz[questionNumber]);
                        rightOrWrong[questionNumber] = rightAnswer;
                    }

                }
            }
        }
    }

}