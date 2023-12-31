﻿using System.IO;
using System.Xml.Serialization;

namespace Quiz_Maker
{
    internal class UserInterface
    {



        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
        }

        public static string PromptForQuestion()
        {
            Console.WriteLine("Please type out the whole question as you would like it printed.");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }

        public static string PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        public static List<string> PromptForAnswers(List<string> answerList)
        {
            bool moreWrongAnswers = true;
            while (moreWrongAnswers)
            {
                Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                Console.WriteLine($"You may have a maximum of {Constants.CHOICE_LIMIT} choices per question.");
                answerList.Add(Console.ReadLine());
               
                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to create more wrong answers for this question?");
                Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            }
            return answerList;
        }

        public static bool PromptForMoreQuestions()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Would you like to create another question?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = userInput.Key == Constants.USER_YES_CHOICE;
            return moreQuestions;
        }

        public static int PromptForQuizAction()
        {
            Console.WriteLine("What would you like to do?(0 to take a quiz, 1 to save a quiz and 2 to load a quiz)\n");
            int quizAction = Convert.ToInt32(Console.ReadLine());
            return quizAction;
        }

        public static List<QuestionAndAnswers> TakeQuiz(List<QuestionAndAnswers> questionAndAnswers)
        {
            bool moreQuestions;
            if (moreQuestions)
            {
                questionAndAnswers.printQuestion;
                questionAndAnswers.rightAnswer;
                questionAndAnswers.wrongAnswers;

                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreQuestions = (userInput.Key == Constants.USER_YES_CHOICE);
            }
        }
    }
}