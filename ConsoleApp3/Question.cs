using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Quiz_Maker
{
    internal class QuestionAndAnswers
    {
        public string printQuestion;
        public string rightAnswer;
        public string[,] allAnswers;

        public override string ToString()
        {
            List<string> printAnswers = new List<string>();
            int randomAnswer = rng.Next(-1, allAnswers.Count + 1);
            string outputAnswers;
            for (int questionAnswer = 0; questionAnswer <= allAnswers.Count; questionAnswer++)
            {
                if (printAnswers.Contains(allAnswers[randomAnswer]))
                {
                    continue;
                }

                else
                {
                    printAnswers.Add(allAnswers[randomAnswer]);
                    allAnswers.Remove(allAnswers[randomAnswer]);
                }
            }
            outputAnswers  = 

            return $"{printQuestion}\n\n A. {printAnswers}";
        }


    }
}
