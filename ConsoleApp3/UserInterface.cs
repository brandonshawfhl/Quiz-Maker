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
            Console.WriteLine("Please type out the whole question as you would like it printed.\n");
            string userQuestion = Console.ReadLine();
            Console.Write("\n");
            return userQuestion;
        }

        /// <summary>
        /// prompts the user for the corret answer to the question
        /// </summary>
        /// <returns>a string that the user types themselves that will be used as the correct answer for their question</returns>
        public static string PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.\n");
            string correctAnswer = Console.ReadLine();
            Console.Write("\n");
            return correctAnswer;
        }

        /// <summary>
        /// prompts the user for the rest of the answers they would like listed as choices that are not correct and then
        /// places them along with the correct answer into an array specifically just for the current question
        /// </summary>
        /// <param name="answerList">the list that will be filled by this method</param>
        /// <returns>a list of strings that the user types that will be used as the other choices for the question</returns>
        public static List<string> PromptForAnswers()
        {
            bool tooManyAnswers = false;
            List<string> incorrectAnswers = new List<string>();
            bool moreWrongAnswers = true;

            for (int answerNumber = 0; answerNumber < Constants.CHOICE_LIMIT; answerNumber++)
            {
                int choicesLeft = Constants.CHOICE_LIMIT - answerNumber;
                Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                Console.WriteLine($"You have {choicesLeft} more choices.\n");
                incorrectAnswers.Add(Console.ReadLine());
                tooManyAnswers = incorrectAnswers.Count >= Constants.CHOICE_LIMIT;
                Console.Write("\n");

                if (tooManyAnswers)
                {
                    Console.WriteLine("You have reached the answer choice limit for this question.\n");
                    break;
                }

                Console.WriteLine($"Would you like to create more wrong answers for this question?");
                Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                Console.Write("\n");
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);

                if (moreWrongAnswers == false)
                {
                    break;
                }
            }
            return incorrectAnswers;
        }

        /// <summary>
        /// Asks user to provide a number that determines what they would like to do with their quiz.
        /// </summary>
        /// <returns>the choice they made in the fom of an enum</returns>
        public static QuizAction.QuizOptions PromptForQuizAction()
        {
            Console.WriteLine("What would you like to do?(0 to make a quiz, 1 to save a quiz and 2 to load a quiz)\n");
            string quizChoiceConversion = Console.ReadLine();
            Console.Write("\n");
            QuizAction.QuizOptions quizChoice = (QuizAction.QuizOptions)Enum.Parse(typeof(QuizAction.QuizOptions), quizChoiceConversion);

            switch (quizChoice)
            {
                case QuizAction.QuizOptions.Make:
                    Console.WriteLine("Beginning the quiz making process now!");
                    break;

                case QuizAction.QuizOptions.Load:
                    Console.WriteLine("Saving your quiz now!");
                    break;

                case QuizAction.QuizOptions.Save:
                    Console.WriteLine("Loading your quiz now!");
                    break;

                default:
                    Console.WriteLine("Invalid entry. Please try again.");
                    break;
            }
            return quizChoice;
        }

        /// <summary>
        /// Asks the user if they would like to continue using the program
        /// </summary>
        /// <returns>returns true or false based on the users answer</returns>
        public static bool PromptForMoreQuizOptions()
        {
            Console.WriteLine("Would you like to keep going?");
            Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuizOptions = (userInput.Key == Constants.USER_YES_CHOICE);

            return moreQuizOptions;
        }

        /// <summary>
        /// Asks the user if they would like to create more questions
        /// </summary>
        /// <returns>true or false depedning on the user's answer</returns>
        public static bool PromptForMoreQuestions()
        {
            Console.WriteLine("Would you like to add another question to this quiz?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = (userInput.Key == Constants.USER_YES_CHOICE);
            return moreQuestions;
        }

        /// <summary>
        /// Prompts the user to answer whether or not they would like to take the quiz currently loaded into the program
        /// </summary>
        /// <returns>true or false that is determined by the user's answer</returns>
        public static bool PromptToTakeQuiz()
        {
            Console.WriteLine("Would you like to take your current quiz?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool takeQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return takeQuiz;
        }

        /// <summary>
        /// prints the entire quiz for the User to see on the screen
        /// </summary>
        /// <param name="currentQuiz">the List of Lists that has the quiz information</param>
        public static void PrintWholeQuiz(List<QuizCard> currentQuiz)
        {
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].questionOutput}\n");
                List<string> answerList = new List<string>()
                {
                    currentQuiz[questionNumber].correctAnswer
                };

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].incorrectAnswers.Count; answerNumber++)
                {
                    answerList.Add(currentQuiz[questionNumber].incorrectAnswers[answerNumber]);
                }

                for (int answerChoice = 0; answerChoice < answerList.Count; answerChoice++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerChoice]}{answerList[answerChoice]}");
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// asks the user if they would like to see the whold quiz
        /// </summary>
        /// <returns>returns true or false based on the user's answer</returns>
        public static bool PromptToSeeWholeQuiz()
        {
            Console.WriteLine("Would you like to see the whole quiz?");
            Console.WriteLine($"{Constants.USER_YES_CHOICE} or press any other key to continue.\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool seeQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return seeQuiz;
        }

        /// <summary>
        /// outputs the next question in the quiz to the user and then prompts them to answer it
        /// </summary>
        /// <param name="correctAnswer"></param>
        /// <returns>true or false based on whether or not the user answered correctly or not</returns>
        public static bool PromptToAnswerQuizQuestion(QuizCard currentQuizCard)
        {
            Console.WriteLine($"{currentQuizCard.questionOutput}\n");
            List<string> answerList = new List<string>()
            {
                currentQuizCard.correctAnswer
            };

            int correctAnswerIndex = answerList.IndexOf(currentQuizCard.correctAnswer);
            foreach (string incorrectAnswer in currentQuizCard.incorrectAnswers)
            {
                answerList.Add(incorrectAnswer);
            }

            foreach (string answer in answerList)
            {
                Console.WriteLine($"{Constants.ANSWER_CHOICES[answerList.IndexOf(answer)]}{answer}\n");
            }

            Console.Write("\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool rightAnswer = (userInput.Key == Constants.ANSWER_KEYS[correctAnswerIndex]);
            return rightAnswer;
        }

        /// <summary>
        /// outputs the entire quiz to the user with the individual score for each question and the overall score of
        /// the whole quiz at the bottom
        /// </summary>
        /// <param name="currentQuiz">list containing currently loaded quiz questions</param>
        /// <param name="rightOrWrong"> list used to score User during quiz</param>
        public static void PrintQuizScore(List<QuizCard> currentQuiz, List<bool> rightOrWrong)
        {
            int numberCorrect = 0;
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].questionOutput}\n");
                List<string> answerList = new List<string>()
                {
                    currentQuiz[questionNumber].correctAnswer
                };

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].incorrectAnswers.Count; answerNumber++)
                {
                    answerList.Add(currentQuiz[questionNumber].incorrectAnswers[answerNumber]);
                }

                for (int answerChoice = 0; answerChoice < answerList.Count; answerChoice++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerChoice]}{answerList[answerChoice]}");
                    Console.WriteLine("\n");
                }

                if (rightOrWrong[questionNumber] == true)
                {
                    Console.WriteLine($"{currentQuiz[questionNumber].correctAnswer} is correct!\n\n");
                    numberCorrect++;
                }
               
                if (rightOrWrong[questionNumber] == false)
                {
                    Console.WriteLine($"Wrong! The correct answer is {currentQuiz[questionNumber].correctAnswer}\n\n");
                }
            }
            Console.WriteLine($"You scored {numberCorrect} out of {currentQuiz.Count} correct!\n\n\n");
        }

        /// <summary>
        /// clears the screen for User
        /// </summary>
        public static void ConsoleClear()
        {
            Console.Clear();
        }

        /// <summary>
        /// prompts the User to decide whether or not they would like to retake the quiz they just took
        /// </summary>
        /// <returns>true or false based on the User's answer</returns>
        public static bool PromptToRetakeQuiz()
        {
            Console.WriteLine("Would you like to take your quiz again?");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool retakeQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return retakeQuiz;
        }

        /// <summary>
        /// prompts the User to decide whether or not they would like to choose another quiz action
        /// </summary>
        /// <returns>true or false based on the User's choice</returns>
        public static bool PromptToContinue()
        {
            Console.WriteLine("Would you like to continue?");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool continuePlaying = (userInput.Key == Constants.USER_YES_CHOICE);
            return continuePlaying;
        }
    }
}