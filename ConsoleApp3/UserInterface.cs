using System.IO;
using System.Xml.Serialization;

namespace Quiz_Maker
{
    internal class UserInterface
    {
        /// <summary>
        /// Writes a message welcoming user to the program.
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!");
        }

        /// <summary>
        /// Prompts user for the question in the way they want it to read.
        /// </summary>
        /// <returns>a string typed by the user that will be used to print their question</returns>
        public static string PromptForQuestion()
        {
            Console.WriteLine("Please type out the whole question as you would like it printed.");
            string userQuestion = Console.ReadLine();
            return userQuestion;
        }

        /// <summary>
        /// prompts the user for the corret answer to the question
        /// </summary>
        /// <returns>a string that the user types themselves that will be used as the correct answer for their question</returns>
        public static string PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }

        /// <summary>
        /// prompts the user for the rest of the answers they would like listed as choices that are not correct
        /// </summary>
        /// <param name="answerList">the list that will be filled by this method</param>
        /// <returns>a list of strings that the user types that will be used as the other choices for the question</returns>
        public static List<string> PromptForAnswers(string correctAnswer)
        {
            bool moreWrongAnswers = true;
            while (moreWrongAnswers)
            {
                int answerNumber = 0;
                bool withinChoiceLimit = answerNumber <= Constants.CHOICE_LIMIT;
                List<string> allAnswers = new List<string>();
                allAnswers.Add(correctAnswer);
                while (withinChoiceLimit)
                {
                    for (answerNumber = 1; answerNumber <= Constants.CHOICE_LIMIT; answerNumber++)
                    {
                        Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                        Console.WriteLine($"You may have a maximum of {Constants.CHOICE_LIMIT} choices per question.");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Would you like to create more wrong answers for this question?");
                        Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
                        allAnswers.Add(Console.ReadLine());
                    }
                }
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            }
            return allAnswers;
        }

        /// <summary>
        /// prompts the user to decide whehther or not they would like to create more answers for their quiz
        /// </summary>
        /// <returns>a true or false based on the user's answer</returns>
        public static bool PromptForMoreQuestions()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Would you like to create another question?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = userInput.Key == Constants.USER_YES_CHOICE;
            return moreQuestions;
        }

        /// <summary>
        /// prompts the user to decide how they would like to use this program
        /// </summary>
        /// <returns>an enum representing the user's choice</returns>
        public static QuizChoice.QuizOptions PromptForQuizAction()
        {
            Console.WriteLine("What would you like to do?(0 to make a quiz, 1 to save a quiz and 2 to load a quiz)\n");
            string quizChoiceConversion = Console.ReadLine();
            QuizChoice.QuizOptions quizChoice = (QuizChoice.QuizOptions)Enum.Parse(typeof(QuizChoice.QuizOptions), quizChoiceConversion);

            switch (quizChoice)
            {
                case QuizChoice.QuizOptions.Make:
                    Console.WriteLine("Beginning the quiz making process now!");
                    break;

                case QuizChoice.QuizOptions.Load:
                    Console.WriteLine("Saving your quiz now!");
                    break;

                case QuizChoice.QuizOptions.Save:
                    Console.WriteLine("Loading your quiz now!");
                    break;

                default:
                    Console.WriteLine("Invalid entry. Please try again.");
                    break;


            }
            return quizChoice;
        }
    }
}