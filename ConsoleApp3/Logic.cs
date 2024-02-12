using System.Xml.Serialization;

namespace Quiz_Maker
{

    internal class Logic
    {
        public static Random rng = new();

        /// <summary>
        /// saves a quiz that the user made
        /// </summary>
        /// <param name="currentQuiz">list of quiz questions and all of their associated information</param>
        /// <returns>the list of quiz questions and all of their associated information that has already been saved</returns>
        public static void SaveQuiz(List<QuizCard> madeQuiz)
        {
            XmlSerializer serializer = new(typeof(List<QuizCard>));
            using FileStream file = File.Create(Constants.PATH);
            serializer.Serialize(file, madeQuiz);
            Console.WriteLine("Your quiz has been successfully save!");
        }

        /// <summary>
        /// loads a quiz from a file
        /// </summary>
        /// <returns>a list of quiz qustions and their associated information</returns>
        public static List<QuizCard> LoadQuiz()
        {
            List<QuizCard> loadedQuiz = new();
            XmlSerializer serializer = new(typeof(List<QuizCard>));

            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                loadedQuiz = (List<QuizCard>)serializer.Deserialize(file);
                Console.WriteLine("Your quiz has been successfully loaded!");
            }
            return loadedQuiz;
        }

        /// <summary>
        /// randomizes the order of the quiz questions
        /// </summary>
        /// <param name="currentQuiz">a list of quiz questions and all of their associated information</param>
        /// <returns>a list of quiz questions and all of their associated information in random order</returns>
        public static List<QuizCard> ShuffleQuizCards(List<QuizCard> currentQuiz)
        {
            List<QuizCard> quizCardList = new();
            List<QuizCard> randomQuiz = new();

            foreach (QuizCard card in currentQuiz)
            {
                List<AnswerPair> randomAnswers = new();

                for (int answerNumber = card.answerChoices.Count; answerNumber > 0; answerNumber--)
                {
                    AnswerPair randomAnswer = card.answerChoices[rng.Next(0, card.answerChoices.Count)];
                    randomAnswers.Add(randomAnswer);
                    card.answerChoices.Remove(randomAnswer);
                }

                card.answerChoices = randomAnswers;
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


