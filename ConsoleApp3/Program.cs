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
            while (anotherQuiz)
            {
                QuizChoice.QuizOptions quizChoice = UserInterface.PromptForQuizAction();

                if (quizChoice == QuizChoice.QuizOptions.Make)
                {

                    List<string> questionList = new List<string>();
                    List<string> correctAnswersList = new List<string>();
                    int questionNumber = -1;
                    bool moreQuestions = true;
                    while (moreQuestions)
                    {
                        questionNumber++;
                        questionList.Add(UserInterface.PromptForQuestion());
                        int choiceNumber = UserInterface.PromptForChoiceNumber();
                        string correctAnswer = UserInterface.PromptForCorrectAnswer();
                        correctAnswersList.Add(correctAnswer);
                        string[][] answerArray = UserInterface.PromptForAnswers(correctAnswer, questionNumber, choiceNumber);
                        moreQuestions = UserInterface.MoreQuestions();
                        madeQuiz.allAnswers = answerArray;
                    }
                    madeQuiz.printQuestions = questionList;
                    madeQuiz.correctAnswers = correctAnswersList;
                }

                if (quizChoice == QuizChoice.QuizOptions.Load)
                {
                    Logic.LoadQuiz();
                }

                if (quizChoice == QuizChoice.QuizOptions.Save)
                {
                    Logic.SaveQuiz(madeQuiz);
                }
            }

                
                userQuiz currentQuiz = new userQuiz();
                Logic.PrintQuiz(currentQuiz);




        }
    }

}