namespace Quiz_Maker
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            bool anotherQuiz = true;
            userQuiz madeQuiz = new userQuiz();

            UserInterface.PrintWelcomeMessage();
            QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

            if (quizChoice == QuizChoice.QuizOptions.Make)
            {
                List<string> questionList = new List<string>();
                List<string> correctAnswersList = new List<string>();
                int questionNumber = 0;
                bool moreQuestions = true;
                string[][] answerArray;
                while (moreQuestions)
                {
                    questionNumber++;
                    string printQuestion = UserInterface.PromptForQuestion();
                    questionList.Add(printQuestion);
                    string correctAnswer = UserInterface.PromptForCorrectAnswer();
                    correctAnswersList.Add(correctAnswer);
                    answerList = UserInterface.PromptForAnswers(correctAnswer);
                    moreQuestions = UserInterface.MoreQuestions();
                }
                    madeQuiz.printQuestions = questionList;
                    madeQuiz.correctAnswers = correctAnswersList;
                    madeQuiz.allAnswers = answerList;

            }

            if (quizChoice == QuizChoice.QuizOptions.Load)
            {
                Logic.LoadQuiz();
            }

            if (quizChoice == QuizChoice.QuizOptions.Save)
            {
                Logic.SaveQuiz(madeQuiz);
            }

            Logic.PrintQuestionAndAnswers(questionAndAnswers);



        }
    }

}