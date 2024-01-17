namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            List<List<string>> currentQuiz = new List<List<string>>();
            bool anotherQuiz = true;
            UserInterface.PrintWelcomeMessage();

            while (anotherQuiz)
            {
                QuizAction.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                if (quizChoice == QuizAction.QuizOptions.Make)
                {
                    List<string> quizCardList = new List<string>();
                  

                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        QuizCard currentQuizCard = new QuizCard();
                        currentQuizCard.questionOutput = UserInterface.PromptForQuestion();
                        quizCardList.Add(currentQuizCard.questionOutput);
                        currentQuizCard.correctAnswer = UserInterface.PromptForCorrectAnswer();
                        correctAnswerList.Add(currentQuizCard.correctAnswer);
                        currentQuizCard.incorrectAnswers = UserInterface.PromptForAnswers();
                        incorrectAnswersList.Add(currentQuizCard.incorrectAnswers);
                        currentQuiz.Add(quizCardList);
                        currentQuiz.Add(correctAnswerList);
                        currentQuiz.Add(incorrectAnswersList);
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
                while (takeQuiz)
                {
                    List<bool> rightOrWrong = new List<bool>();
                    for (int questionNumber = 0; questionNumber <= currentQuiz.Count; questionNumber++)
                    {
                        bool rightAnswer = UserInterface.PromptToAnswerQuizQuestion();
                    }
                }
            }


        }
    }

}