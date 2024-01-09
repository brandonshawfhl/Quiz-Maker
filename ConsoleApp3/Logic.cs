﻿using static Quiz_Maker.UserInterface;
using System.Xml.Serialization;
namespace Quiz_Maker
{
    internal class Logic
    {
        public static List<QuestionAndAnswers> QuizOptions(List<QuestionAndAnswers> questionAndAnswersFile, int quizAction)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
            var path = @"C:\tmp\questionAndAnswersList.xml";
            if (quizAction == Constants.SAVE_CHOICE)
            {
                path = Console.ReadLine();
                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, questionAndAnswersFile);
                }
            }

                if(quizAction == Constants.LOAD_CHOICE)
            {
                path = Console.ReadLine();
                using (FileStream file = File.OpenRead(path))
                {
                    questionAndAnswersFile = serializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
            }
            return questionAndAnswersFile;
        }

        public static string[,] AnswerArray(List<string> answerList)
        {
            string[,] answerArray = new string[Constants.ANSWER_COLUMN, Constants.CHOICE_LIMIT];
            answerArray[0, Constants.LETTER_A] = "A.\t";
            answerArray[0, Constants.LETTER_B] = "B.\t";
            answerArray[0, Constants.LETTER_C] = "C.\t";
            answerArray[0, Constants.LETTER_D] = "D.\t";
            answerArray[0, Constants.LETTER_E] = "E.\t";
            answerArray[0, Constants.LETTER_F] = "F.\t";
            answerArray[0, Constants.LETTER_G] = "G.\t";
            answerArray[0, Constants.LETTER_H] = "H.\t";
            answerArray[0, Constants.LETTER_I] = "I.\t";
            answerArray[0, Constants.LETTER_J] = "J.\t";
            int answerListCount = answerList.Count();
            for (int answerNumber = 1; answerNumber <= answerListCount; answerNumber++)
            {
                int randomNumber = Program.rng.Next(-1, answerList.Count);
                answerList[randomNumber] = answerArray[1, answerNumber];
                answerList.Remove(answerList[randomNumber]);
            }
            return answerArray;
        }

    }
}
