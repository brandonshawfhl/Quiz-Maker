using static Quiz_Maker.UserInterface;
using System.Xml.Serialization;
namespace Quiz_Maker
{

    internal class Logic
    {
        public static Random rng = new Random();

        /// <summary>
        /// saves a quiz that the user made
        /// </summary>
        /// <param name="questionAndAnswersFile">the list that will store the file</param>
        /// <returns>a list that can be used to run a quiz</returns>
        public static void SaveQuiz(List<QuizCard> currentQuiz)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));
            var path = @"currentQuiz.xml";
            path = Console.ReadLine();
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, currentQuiz);
            }
        }

        /// <summary>
        /// loads a quiz from a file
        /// </summary>
        /// <param name="questionAndAnswersFile">a list that will store the loaded file</param>
        /// <returns>a loaded file that can run a quiz</returns>
        public static List<QuizCard> LoadQuiz()
        {
            List<QuizCard> loadedQuiz = new List<QuizCard>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));
            var path = @"currentQuiz.xml";
            path = Console.ReadLine();
            using (FileStream file = File.OpenRead(path))
            {
                loadedQuiz = serializer.Deserialize(file) as List<QuizCard>;
            }
            return loadedQuiz;
        }

        /// <summary>
        /// populates list used to score the User during the quiz
        /// </summary>
        /// <param name="currentQuiz">list containing the currently loaded quiz questions</param>
        /// <returns>list used to score User</returns>
        public static List<bool> GetScoringList(List<QuizCard> currentQuiz)
        {
            List<bool> rightOrWrong = new List<bool>();
            foreach (QuizCard question in currentQuiz)
            {
                rightOrWrong.Add(false);
            }
            return rightOrWrong;
        }
    }
}
