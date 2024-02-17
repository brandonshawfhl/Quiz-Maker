﻿namespace Quiz_Maker
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

                do
                {
                    quizChoice = UserInterface.PromptForQuizAction();
                }
                while (quizChoice == default);

                bool saveQuiz;

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
                        saveQuiz = UserInterface.PromptToSave();

                        if (saveQuiz)
                        {
                            Logic.SaveQuiz(madeQuiz);
                        }
                    }
                }

                if (quizChoice == QuizAction.QuizOptions.Load)
                {
                    madeQuiz = Logic.LoadQuiz();
                    UserInterface.PrintSuccessfulLoadMessage();
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
                        int questionNumber = UserInterface.GetQuestionNumber();
                        bool editQuestion = UserInterface.PromptToEditQuestion();

                        if (editQuestion)
                        {
                            currentQuiz[questionNumber].question = UserInterface.EditQuestion(currentQuiz, questionNumber);
                        }

                        bool editAnswers = UserInterface.PromptToEditAnswers();

                        while (editAnswers)
                        {
                            int answerNumber = UserInterface.GetAnswerNumber();
                            currentQuiz[questionNumber].answerChoices[answerNumber] =
                                UserInterface.EditAnswer(currentQuiz, questionNumber, answerNumber);
                            editAnswers = UserInterface.PromptToEditAnswers();
                        }

                        saveQuiz = UserInterface.PromptToSave();

                        if (saveQuiz)
                        {
                            Logic.SaveQuiz(madeQuiz);
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