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
    }
}
