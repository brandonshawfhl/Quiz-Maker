﻿namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questionList = new List<Question>();
            List<CorrectAnswer> correctAnswersList = new List<CorrectAnswer>();
            List<WrongAnswers> wrongAnswersList = new List<WrongAnswers>();
            bool userStillNeedsMoreQuestions = true;

            {
                UserInterface.PrintWelcomeMessage();
                Question userQuestion = new Question();
                userQuestion.questionWording = Console.ReadLine();
                questionList.Add(userQuestion);
                UserInterface.PrintEnterCorrectAnswerMessage();
                CorrectAnswer userQuestionCorrectAnswer = new CorrectAnswer();
                userQuestionCorrectAnswer.correctAnswerWording = Console.ReadLine();
                correctAnswersList.Add(userQuestionCorrectAnswer);
                UserInterface.PrintEnterWrongAnswersMessage();
                {
                    bool wantsToCreateMoreWrongAnswers = false;
                    WrongAnswers.wrongAnswersList.Add(Console.ReadLine());
                    questionAndAnswersList.Add(userQuestionAndAnswers);
                    wantsToCreateMoreWrongAnswers = UserInterface.IsCreateMoreWrongAnswers();
                } while (playAgain == Constants.USER_YES_CHOICE) ;)
            } while (userStillNeedsMoreQuestions) ;
        }
    }

}