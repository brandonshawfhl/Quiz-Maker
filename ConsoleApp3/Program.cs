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

                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        List<string> currentQuizCard = new List<string>();
                        QuizQuestion currentQuestion = new QuizQuestion();
                        currentQuestion.questionOutput = UserInterface.PromptForQuestion();
                        currentQuizCard.Add(currentQuestion.questionOutput);
                        CorrectAnswer currentCorrectAnswer = new CorrectAnswer();
                        currentCorrectAnswer.correctAnswerOutput = UserInterface.PromptForCorrectAnswer();
                        currentQuizCard.Add(currentCorrectAnswer.correctAnswerOutput);
                        IncorrectAnswers currentIncorrectAnswers = new IncorrectAnswers();
                        currentIncorrectAnswers.incorrectAnswersOuput = UserInterface.PromptForAnswers();
                        for (int answerNumber = 1; answerNumber <= currentIncorrectAnswers.incorrectAnswersOuput.Count; answerNumber++)
                        {
                            currentQuizCard.Add(currentIncorrectAnswers.incorrectAnswersOuput[answerNumber]);
                        }
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