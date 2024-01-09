using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Quiz_Maker
{
    internal class QuestionAndAnswers
    {
        public string printQuestion;
        public string correctAnswer;
        public string[,] allAnswers;

        public void PrintQuestionAndAnswers(QuestionAndAnswers userQuestion)
        {
            Console.WriteLine(userQuestion.printQuestion);
            for (int allAnswersCount = 0; allAnswersCount <= allAnswers.Length; allAnswersCount++)
            {
                Console.WriteLine($"{userQuestion.allAnswers[1, allAnswersCount]}");
            }
        }
    }
}
