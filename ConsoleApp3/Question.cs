namespace Quiz_Maker
{
    internal class QuestionAndAnswers
    {
        public string printQuestion;
        public string rightAnswer;
        public string[] allAnswers;

        public static readonly Random rng = new Random();

        public override string ToString()
        {
           Shuffle<allAnswers>(allAnswers[] allAnswers.Count);
           
            return $"{printQuestion}\n\n {allAnswers.}
        }
    }
}
