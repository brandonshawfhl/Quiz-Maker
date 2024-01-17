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
                while (seeQuiz)
                {
                    seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                    UserInterface.PrintWholeQuiz(currentQuiz);
                }

                bool takeQuiz = true;
                takeQuiz = UserInterface.PromptToTakeQuiz();
                if (takeQuiz)
                {
                    List<bool> rightOrWrong = new List<bool>();
                    for (int questionNumber = 0; questionNumber <= currentQuiz.Count; questionNumber++)
                    {
                        ConsoleKey correctAnswer = currentQuiz[questionNumber].
                        bool rightAnswer = UserInterface.PromptToAnswerQuizQuestion(questionNumber, correctAnswer, currentQuiz[questionNumber]);
                    }
                }
            }


        }
    }

}