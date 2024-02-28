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
                quizChoice = UserInterface.PromptQuizAction();

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
                        moreQuestions = UserInterface.PromptMoreQuestions();
                        UserInterface.ConsoleClear();
                        saveQuiz = UserInterface.PromptSave();

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
                bool seeQuiz = UserInterface.PromptSeeQuiz();
                UserInterface.ConsoleClear();

                if (seeQuiz)
                {
                    UserInterface.PrintQuiz(currentQuiz);
                }

                bool makeChanges = UserInterface.PromptMakeChanges();

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

                    bool editAnswers = UserInterface.PromptEditAnswers();

                    while (editAnswers)
                    {
                        bool answerDoesntExist = true;
                        int answerNumber = 0;

                        while (answerDoesntExist)
                        {
                            answerNumber = UserInterface.GetAnswerNumber();
                            answerDoesntExist = Logic.IsAnswerValid(questionNumber, answerNumber, currentQuiz);

                            if (answerDoesntExist)
                            {
                                UserInterface.PrintAnswerDoesntExistMessage();
                            }
                        }

                        currentQuiz[questionNumber - 1].answerChoices[answerNumber] =
                            UserInterface.EditAnswer(currentQuiz, questionNumber, answerNumber);
                        editAnswers = UserInterface.PromptEditAnotherAnswer();
                    }

                    seeQuiz = UserInterface.PromptSeeQuiz();

                    if (seeQuiz)
                    {
                        UserInterface.PrintQuiz(currentQuiz);
                    }

                    saveQuiz = UserInterface.PromptSave();

                    if (saveQuiz)
                    {
                        Logic.SaveQuiz(madeQuiz);
                        UserInterface.PrintSuccessfulSaveMessage();
                    }

                    makeChanges = UserInterface.PromptMoreChanges();
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
                        UserInterface.PrintScore(currentQuiz, userAnswers);
                        takeQuiz = UserInterface.PromptPlayQuizAgain();
                        UserInterface.ConsoleClear();
                    }

                    else
                    {
                        Console.WriteLine("Sorry you do not have any quiz data stored.");
                        Console.WriteLine("Please create or load a quiz to continue.");
                        break;
                    }
                }

                anotherAction = UserInterface.PromptContinue();
            }
        }
    }
}
