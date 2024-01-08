using static Quiz_Maker.UserInterface;
using System.Xml.Serialization;
namespace Quiz_Maker
{
    internal class Logic
    {
        public static void QuizOptions(List<QuestionAndAnswers> questionAndAnswersFile, List<QuestionAndAnswers> quizAction, Enum.QuizAction choice)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
            var path = @"C:\tmp\questionAndAnswersList.xml";
            switch (choice)
            {
                case Enum.QuizAction.Take:
                    Console.WriteLine();
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                        break;

                case Enum.QuizAction.Save:
                    path = Console.ReadLine();
                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, questionAndAnswersFile);
                    }
                    break;

                case Enum.QuizAction.Load:
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                    {
                        questionAndAnswersFile = serializer.Deserialize(file) as List<QuestionAndAnswers>;
                    }
                    break;
            }
        }

        public static string[,] AnswerArray(List<string> answerList)
        {
            string[,] answerArray = new string[Constants.ANSWER_COLUMN, Constants.CHOICE_LIMIT];
            int answerListCount = answerList.Count();
            for (int answerNumber = 1; answerNumber <= answerListCount; answerNumber++)
            {
                int randomNumber = Program.rng.Next(-1, answerList.Count);
                answerList[randomNumber] = answerArray[answerNumber, answerNumber];
                answerList.Remove(answerList[randomNumber]);
            }
            return answerArray;
        }

    }
}
