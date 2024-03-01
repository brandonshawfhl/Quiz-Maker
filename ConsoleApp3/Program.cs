namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new();
        static void Main(string[] args)
        {
            UserInterface.PrintWelcomeMessage();
            bool anotherAction = true;
            List<QuizCard> currentQuiz = new();

            while (anotherAction)
            {
                UserInterface.ConsoleClear();
                QuizAction.QuizOptions quizChoice = QuizAction.QuizOptions.Default;

                if (currentQuiz.Count > 0)
                {
                    bool replaceQuiz = UserInterface.PromptReplaceQuiz();

                    if (replaceQuiz)
                    {
                        currentQuiz.Clear();
                    }

                    else
                    {
                        quizChoice = UserInterface.PromptQuizOptions();
                    }
                }

                QuizAction.QuizCreation quizData = QuizAction.QuizCreation.Default;

                if (currentQuiz.Count == 0)
                {
                    quizData = UserInterface.PromptQuizCreation();
                }

                bool saveQuiz;

                //user creates a quiz from scratch or edits a quiz that is currently active in the Program
                if (QuizAction.QuizCreation.Make == quizData || QuizAction.QuizOptions.Add == quizChoice)
                {
                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new()
                        {
                            question = UserInterface.PromptForQuestion(),
                            answerChoices = UserInterface.PromptForAnswers()
                        };

                        currentQuiz.Add(currentQuizCard);
                        moreQuestions = UserInterface.PromptMoreQuestions();
                        UserInterface.ConsoleClear();
                        saveQuiz = UserInterface.PromptSave();

                        if (saveQuiz)
                        {
                            Logic.SaveQuiz(currentQuiz);
                            UserInterface.PrintSuccessfulSaveMessage();
                        }
                    }
                }

                //loads a quiz from a file
                if (QuizAction.QuizCreation.Load == quizData)
                {
                    List<QuizCard> loadedQuiz = Logic.LoadQuiz();

                    if (loadedQuiz.Count > 0)
                    {
                        UserInterface.PrintSuccessfulLoadMessage();
                        currentQuiz = loadedQuiz;
                    }

                    else
                    {
                        UserInterface.PrintFailedLoadMessage();
                    }
                }


                //user edits quiz
                if (QuizAction.QuizOptions.Edit == quizChoice)
                {
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
                            Logic.SaveQuiz(currentQuiz);
                            UserInterface.PrintSuccessfulSaveMessage();
                        }

                        makeChanges = UserInterface.PromptMoreChanges();
                    }
                }


                if (QuizAction.QuizOptions.Take == quizChoice)
                {
                    List<QuizCard> shuffledQuiz = Logic.ShuffleQuizCards(currentQuiz);
                    UserInterface.ConsoleClear();
                    bool takeQuiz = true;
                    while (takeQuiz)
                    {
                        if (shuffledQuiz.Count > 0)
                        {
                            UserInterface.ConsoleClear();
                            List<int> userAnswers = UserInterface.PlayQuiz(shuffledQuiz);
                            UserInterface.ConsoleClear();
                            UserInterface.PrintScore(shuffledQuiz, userAnswers);
                            takeQuiz = UserInterface.PromptPlayQuizAgain();
                            UserInterface.ConsoleClear();
                        }

                        else
                        {
                            UserInterface.PrintNoQuizStoredMessage();
                            break;
                        }
                    }
                }

                anotherAction = UserInterface.PromptContinue();
            }
        }
    }
}

