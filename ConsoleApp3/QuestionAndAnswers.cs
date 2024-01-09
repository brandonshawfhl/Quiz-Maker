using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Quiz_Maker
{
    internal class QuestionAndAnswers
    {
        public string printQuestion;
        public string correctAnswer;
        public string[,] allAnswers;

        public void PrintQuestionAndAnswers(List<QuestionAndAnswers> questionAndAnswers)
        {
            for (int questionNumber = 0; questionNumber <= questionAndAnswers.Count; questionNumber++)
            {
                QuestionAndAnswers userQuestion = questionAndAnswers[0];
                Console.WriteLine(userQuestion.printQuestion);
                for (int allAnswersCount = 0; allAnswersCount <= allAnswers.Length; allAnswersCount++)
                {
                    Console.WriteLine($"{userQuestion.allAnswers[0, allAnswersCount]}{userQuestion.allAnswers[1, allAnswersCount]}");
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
