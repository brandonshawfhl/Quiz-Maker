﻿using System.Collections.Generic;

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

                if (quizChoice == QuizAction.QuizOptions.Make)
                {
                    bool moreQuestions = true;

                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new QuizCard();
                        currentQuizCard.questionOutput = UserInterface.PromptForQuestion();
                        currentQuizCard.correctAnswer = UserInterface.PromptForCorrectAnswer();
                        currentQuizCard.incorrectAnswers = UserInterface.PromptForAnswers();
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
                    List<bool> rightOrWrong = new List<bool>();
                    UserInterface.ConsoleClear();

                    for (int questionNumber = 0; questionNumber <= currentQuiz.Count - 1; questionNumber++)
                    {
                        bool rightAnswer = UserInterface.PromptToAnswerQuizQuestion(currentQuiz, answerList, questionNumber);
                        rightOrWrong.Add(rightAnswer);
                    }

                    UserInterface.ConsoleClear();
                    UserInterface.PrintQuizScore(currentQuiz, rightOrWrong, answerList);
                    takeQuiz = UserInterface.IsPlayQuizAgain();
                    UserInterface.ConsoleClear();
                }
                anotherAction = UserInterface.PromptToContinue();
            }
        }
    }
}