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

        public static int PromptForChoiceNumber()
        {

            Console.WriteLine("How many choices would you like the user to have for this question?");
            int choiceNumber = Convert.ToInt32(Console.ReadLine());
            return choiceNumber;
        }
        
        /// <summary>
        /// prompts the user for the rest of the answers they would like listed as choices that are not correct
        /// </summary>
        /// <param name="answerList">the list that will be filled by this method</param>
        /// <returns>a list of strings that the user types that will be used as the other choices for the question</returns>
        public static List<string> PromptForAnswers(string correctAnswer)
        {
            List<string> allAnswers = new List<string>();
            bool moreWrongAnswers = true;
            while (moreWrongAnswers)
            {
                int answerNumber = 0;
                bool tooManyAnswers = answerNumber >= Constants.CHOICE_LIMIT;
                allAnswers.Add(correctAnswer);

                for (answerNumber = 1; answerNumber <= Constants.CHOICE_LIMIT; answerNumber++)
                {
                    Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                    Console.WriteLine($"You may have a maximum of {Constants.CHOICE_LIMIT} choices per question.");
                    allAnswers.Add(Console.ReadLine());
                    Console.WriteLine("\n");
                    Console.WriteLine($"Would you like to create more wrong answers for this question?");
                    Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
                    ConsoleKeyInfo userInput = Console.ReadKey(true);
                    moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);

                    if (tooManyAnswers)
                    {
                        Console.WriteLine("You have reached the answer choice limit for this question.");
                    }
                }
            }
            return allAnswers;
        }

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

        public static bool AnotherQuizOption()
        {
            Console.WriteLine("Would you like to keep going?");
            Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuizOptions = (userInput.Key == Constants.USER_YES_CHOICE);

            return moreQuizOptions;

        }

        public static bool MoreQuestions()
        {
            Console.WriteLine("Would you like to add another question to this quiz?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = (userInput.Key == Constants.USER_YES_CHOICE);
            return moreQuestions;
        }
    }
}