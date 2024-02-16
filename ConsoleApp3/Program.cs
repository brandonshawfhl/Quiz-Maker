namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new();
        static void Main(string[] args)
        {
            bool anotherAction = true;
            List<QuizCard> madeQuiz = new();

            while (anotherAction)
            {
                UserInterface.ConsoleClear();
                UserInterface.PrintWelcomeMessage();
                QuizAction.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                //user creates a quiz from scratch
                if (quizChoice == QuizAction.QuizOptions.Make)
                {
                    bool moreQuestions = true;

                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new()
                        {
                            question = UserInterface.PromptForQuestion(),
                            answerChoices = UserInterface.PromptForAnswers()
                        };
                        madeQuiz.Add(currentQuizCard);
                        moreQuestions = UserInterface.PromptForMoreQuestions();
                        UserInterface.ConsoleClear();
                    }
                }

                if (quizChoice == QuizAction.QuizOptions.Load)
                {
                    madeQuiz = Logic.LoadQuiz();
                }

                if (quizChoice == QuizAction.QuizOptions.Save)
                {
                    Logic.SaveQuiz(madeQuiz);
                }

                List<QuizCard> currentQuiz = Logic.ShuffleQuizCards(madeQuiz);
                bool seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                UserInterface.ConsoleClear();

                if (seeQuiz)
                {
                    UserInterface.PrintWholeQuiz(currentQuiz);
                }

                bool makeChanges = UserInterface.PromptToMakeChanges();

                if (makeChanges)
                {
                    int questionNumber = UserInterface.GetQuestionNumber();
                }


                bool takeQuiz = UserInterface.IsPlayQuiz();
                UserInterface.ConsoleClear();

                while (takeQuiz)
                {
                    if (currentQuiz.Count > 0)
                    {
                        UserInterface.ConsoleClear();
                        List<int> userAnswers = UserInterface.PlayQuiz(currentQuiz);
                        UserInterface.ConsoleClear();
                        UserInterface.PrintQuizScore(currentQuiz, userAnswers);
                        takeQuiz = UserInterface.IsPlayQuizAgain();
                        UserInterface.ConsoleClear();
                    }

                    else
                    {
                        Console.WriteLine("Sorry you do not have any quiz data stored.");
                        Console.WriteLine("Please create or load a quiz to continue.");
                        break;
                    }
                }
                anotherAction = UserInterface.PromptToContinue();
            }
        }
    }
}