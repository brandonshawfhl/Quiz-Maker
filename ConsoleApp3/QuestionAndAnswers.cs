using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Quiz_Maker
{
    internal class QuestionAndAnswers
    {
        public string printQuestion;
        public string correctAnswer;
        public string[,] allAnswers;

        public override string ToString()
        {
            for (int allAnswersCount = 0; allAnswersCount <= allAnswers.Length; allAnswersCount++)
            {

            }
            
          

            return $"{printQuestion}\n\n ";
        }


    }
}
