namespace Quiz_Maker
{
    internal class Logic
    {
        public class Question
        {
            public string PrintQuestion;
            public string CorrectAnswer;
            public List<String> WrongAnswers;
        }

        Question firstQuestion = new Question();

        firstQuestion.PrintQuestion = "What color is the grass";

    }
}
