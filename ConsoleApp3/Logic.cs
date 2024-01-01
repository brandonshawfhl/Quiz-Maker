using static Quiz_Maker.UserInterface;
using System.Xml.Serialization;

namespace Quiz_Maker
{
    internal class Logic
    {
        public enum QuizAction
        {
            Take,
            Save,
            Load
        }

        public static void QuizOptions(List<QuestionAndAnswers> questionAndAnswersList, QuizAction choice)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
            List<QuestionAndAnswers> quizActionList = new List<QuestionAndAnswers>();
            var path = @"C:\tmp\questionAndAnswersList.xml";
            switch (choice)
            {
                case QuizAction.Take:
                    Console.WriteLine();
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                        break;

                case QuizAction.Save:
                    path = Console.ReadLine();
                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, questionAndAnswersList);
                    }
                    break;

                case QuizAction.Load:
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                    {
                        quizActionList = serializer.Deserialize(file) as List<QuestionAndAnswers>;
                    }
                    break;
            }
        }
    }
}
