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
                int questionNumber = 0;
                bool moreQuestions = true;
                while (moreQuestions)
                {
                    questionNumber++;
                    List<string> questionList = new List<string>();
                    string printQuestion = UserInterface.PromptForQuestion();
                    questionList.Add(printQuestion);
                    string[][] answerArray;
                    List<string> correctAnswersList = new List<string>();
                    string correctAnswer = UserInterface.PromptForCorrectAnswer();
                    correctAnswersList.Add(correctAnswer);
                    madeQuiz.correctAnswers = correctAnswersList;
                    answerList = UserInterface.PromptForAnswers(correctAnswer);
                    madeQuiz.printQuestions = questionList;
                    madeQuiz.allAnswers = answerList;
                    moreQuestions = UserInterface.MoreQuestions();
                }
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