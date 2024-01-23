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
            using (FileStream file = File.Create(Constants.PATH))
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
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));
            List<QuizCard> loadedQuiz = new List<QuizCard>();
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                loadedQuiz = (List<QuizCard>)serializer.Deserialize(file);
            }
            return loadedQuiz;
        }

        public static List<List<string>> GetRandomAnswers(List<QuizCard> currentQuiz)
        {
            List<List<string>> answerList = new List<List<string>>();
            List<string> initialList = new List<string>();

            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                List<string> randomAnswers = new List<string>();
                initialList.Add(currentQuiz[questionNumber].correctAnswer);
                foreach (string incorrectAnswer in currentQuiz[questionNumber].incorrectAnswers)
                {
                    initialList.Add(incorrectAnswer);
                }

                for (int answerNumber = initialList.Count; answerNumber > 0; answerNumber--)
                {
                    string randomAnswer = initialList[rng.Next(0, initialList.Count)];
                    randomAnswers.Add(randomAnswer);
                    initialList.Remove(randomAnswer);
                }
                answerList.Add(randomAnswers);
            }
            return answerList;
        }

        public static List<QuizCard> GetRandomQuizCard(List<QuizCard> currentQuiz)
        {
            List<QuizCard> quizCardList = new List<QuizCard>();
            List<QuizCard> randomQuiz = new List<QuizCard>();
            foreach (QuizCard card in currentQuiz)
            {
                quizCardList.Add(card);
            }

            for (int questionNumber = currentQuiz.Count; questionNumber > 0; questionNumber--)
            {
                QuizCard randomQuizCard = quizCardList[rng.Next(0, quizCardList.Count)];
                randomQuiz.Add(randomQuizCard);
                quizCardList.Remove(randomQuizCard);
            }
            return randomQuiz;
        }

    }
}

