using System.Xml.Serialization;

namespace Quiz_Maker
{

    internal class Logic
    {
        public static Random rng = new Random();

        /// <summary>
        /// saves a quiz that the user made
        /// </summary>
        /// <param name="currentQuiz">list of quiz questions and all of their associated information</param>
        /// <returns>the list of quiz questions and all of their associated information that has already been saved</returns>
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
        /// <returns>a list of quiz qustions and their associated information</returns>
        public static List<QuizCard> LoadQuiz()
        {
            List<QuizCard> loadedQuiz = new List<QuizCard>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                loadedQuiz = (List<QuizCard>)serializer.Deserialize(file);
            }
            return loadedQuiz;
        }

        /// <summary>
        /// randomizes the order of the answer choices for each quiz question
        /// </summary>
        /// <param name="currentQuiz">a list of quiz questions and all of their associated information</param>
        /// <returns>a list of lists of answers in random order for each quiz question</returns>
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

        /// <summary>
        /// randomizes the order of the quiz questions
        /// </summary>
        /// <param name="currentQuiz">a list of quiz questions and all of their associated information</param>
        /// <returns>a list of quiz questions and all of their associated information in random order</returns>
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

