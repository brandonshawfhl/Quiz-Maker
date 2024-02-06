namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            bool anotherAction = true;

            while (anotherAction)
            {
                UserInterface.ConsoleClear();
                UserInterface.PrintWelcomeMessage();
                QuizAction.QuizOptions quizChoice = UserInterface.PromptForQuizAction();
                List<QuizCard> madeQuiz = new List<QuizCard>();

                //user creates a quiz from scratch
                if (quizChoice == QuizAction.QuizOptions.Make)
                {
                    bool moreQuestions = true;

                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new QuizCard();
                        currentQuizCard.questionOutput = UserInterface.PromptForQuestion();
                        currentQuizCard.answerChoices = UserInterface.PromptForAnswers();
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
                List<List<string>> answerList = Logic.ShuffleAnswers(currentQuiz);
                bool seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                UserInterface.ConsoleClear();

                if (seeQuiz)
                {
                    UserInterface.PrintWholeQuiz(currentQuiz, answerList);
                }

                bool takeQuiz = UserInterface.IsPlayQuiz();
                UserInterface.ConsoleClear();

                while (takeQuiz)
                {
                    if (currentQuiz.Count > 0)
                    {
                        UserInterface.ConsoleClear();
                        List<bool> rightOrWrong = UserInterface.PlayQuiz(currentQuiz, answerList);
                        UserInterface.ConsoleClear();
                        UserInterface.PrintQuizScore(currentQuiz, rightOrWrong, answerList);
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