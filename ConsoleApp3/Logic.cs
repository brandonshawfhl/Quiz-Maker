﻿using static Quiz_Maker.UserInterface;
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
    }
}
