using System.Collections.Generic;

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
                List<QuizCard> currentQuiz = Logic.GetRandomQuizCard(madeQuiz);
                List<List<string>> answerList = Logic.GetRandomAnswers(currentQuiz);

                if (quizChoice == QuizAction.QuizOptions.Load)
                {
                    currentQuiz = Logic.LoadQuiz();
                }

                if (quizChoice == QuizAction.QuizOptions.Save)
                {
                    Logic.SaveQuiz(currentQuiz);
                }

                bool seeQuiz = UserInterface.PromptToSeeWholeQuiz();
                UserInterface.ConsoleClear();

                if (seeQuiz)
                {
                    UserInterface.PrintWholeQuiz(currentQuiz, answerList);
                }

                bool takeQuiz = UserInterface.PromptToTakeQuiz();
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
                    takeQuiz = UserInterface.PromptToRetakeQuiz();
                    UserInterface.ConsoleClear();
                }
                anotherAction = UserInterface.PromptToContinue();
            }
        }
    }
}