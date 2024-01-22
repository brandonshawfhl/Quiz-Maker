using static Quiz_Maker.UserInterface;
using System.Xml.Serialization;
using System.Dynamic;

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

        public static List<string> GetRandomAnswers(List<QuizCard> currentQuiz)
        {
            List<string> randomAnswers = new List<string>();
            List<string> answerList = new List<string>();

            for (int questionNumber = 0; questionNumber <= currentQuiz.Count; questionNumber++)
            {
                answerList.Add(currentQuiz[questionNumber].correctAnswer);
                foreach (string incorrectAnswer in currentQuiz[questionNumber].incorrectAnswers)
                {
                    answerList.Add(incorrectAnswer);
                }

                for (int answerNumber = answerList.Count; answerNumber > 0; answerNumber--)
                {
                    string randomAnswer = answerList[rng.Next(0, answerList.Count)];
                    randomAnswers.Add(randomAnswer);
                    answerList.Remove(randomAnswer);
                }
            }
            return randomAnswers;
        }

        public static List<QuizCard> GetRandomQuizCard(List<QuizCard> currentQuiz)
        {
            List<QuizCard> quizCardList = new List<QuizCard>();
            List<QuizCard> randomQuiz = new List<QuizCard>();
            foreach (QuizCard card in currentQuiz)
            {
                quizCardList.Add(card);
            }

            for (int questionNumber = 0; questionNumber <= currentQuiz.Count; questionNumber++)
            {
                QuizCard randomQuizCard = quizCardList[rng.Next(0, quizCardList.Count)];
                randomQuiz.Add(randomQuizCard);
                quizCardList.Remove(randomQuizCard);
            }
            return randomQuiz;
        }

    }
}

