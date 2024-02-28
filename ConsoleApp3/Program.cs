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
                QuizAction.QuizOptions quizChoice;
                quizChoice = UserInterface.PromptForQuizAction();

                bool saveQuiz;

                //user creates a quiz from scratch
                if (QuizAction.QuizOptions.Make == quizChoice)
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
                        saveQuiz = UserInterface.PromptToSave();

                        if (saveQuiz)
                        {
                            Logic.SaveQuiz(madeQuiz);
                            UserInterface.PrintSuccessfulSaveMessage();
                        }
                    }
                }

                if (QuizAction.QuizOptions.Load == quizChoice)
                {
                    List<QuizCard> loadedQuiz = Logic.LoadQuiz();

                    if (loadedQuiz.Count > 0)
                    {
                        UserInterface.PrintSuccessfulLoadMessage();
                        madeQuiz = loadedQuiz;
                    }

                    else
                    {
                        UserInterface.PrintFailedLoadMessage();
                    }
                }

                List<QuizCard> currentQuiz = Logic.ShuffleQuizCards(madeQuiz);
                bool seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                UserInterface.ConsoleClear();

                if (seeQuiz)
                {
                    UserInterface.PrintWholeQuiz(currentQuiz);

                    bool makeChanges = UserInterface.PromptToMakeChanges();

                    while (makeChanges)
                    {
                        int questionNumber = 0;
                        bool questionDoesntExist = true;

                        while (questionDoesntExist)
                        {
                            questionNumber = UserInterface.GetQuestionNumber();
                            questionDoesntExist = Logic.IsQuestionValid(questionNumber, currentQuiz);

                            if (questionDoesntExist)
                            {
                                UserInterface.PrintQuestionDoesntExistMessage();
                            }
                        }

                        bool editQuestion = UserInterface.PromptEditQuestion();

                        if (editQuestion)
                        {
                            currentQuiz[questionNumber - 1].question = UserInterface.EditQuestion(currentQuiz, questionNumber);
                        }

                        bool editAnswers = true;

                        while (editAnswers)
                        {
                            editAnswers = UserInterface.PromptEditAnswers();
                            int answerNumber = UserInterface.GetAnswerNumber(currentQuiz);
                            currentQuiz[questionNumber - 1].answerChoices[answerNumber] =
                                UserInterface.EditAnswer(currentQuiz, questionNumber, answerNumber);
                        }

                        saveQuiz = UserInterface.PromptToSave();

                        if (saveQuiz)
                        {
                            Logic.SaveQuiz(madeQuiz);
                            UserInterface.PrintSuccessfulSaveMessage();
                        }

                        makeChanges = UserInterface.PromptToMakeMoreChanges();
                    }
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