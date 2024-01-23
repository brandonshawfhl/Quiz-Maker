namespace Quiz_Maker
{
    internal class UserInterface
    {
        /// <summary>
        /// Writes a message welcoming user to the program.
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Quiz Maker where you can make your own quiz!\n");
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
        /// <returns>a string that the User types themselves that will be used as the correct answer for their question</returns>
        public static string PromptForCorrectAnswer()
        {
            Console.WriteLine("Please enter the correct answer for this question.\n");
            string correctAnswer = Console.ReadLine();
            Console.Write("\n");
            return correctAnswer;
        }

        /// <summary>
        /// prompts the User for the rest of the answers they would like listed as choices that are not correct and then
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
        /// asks user to provide a number that determines what they would like to do int this program
        /// </summary>
        /// <returns>the choice they made in the form of an enum</returns>
        public static QuizAction.QuizOptions PromptForQuizAction()
        {
            Console.WriteLine("What would you like to do?(Enter 0 to make a quiz, 1 to save a quiz and 2 to load a quiz.)");
            Console.WriteLine("Once you have entered the corresponding number, press enter to continue.\n");
            string quizChoiceConversion = Console.ReadLine();
            QuizAction.QuizOptions quizChoice = (QuizAction.QuizOptions)Enum.Parse(typeof(QuizAction.QuizOptions), quizChoiceConversion);
            Console.Clear();

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
        /// asks the user if they would like to continue using the program
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
        public static bool IsPlayQuiz()
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
        /// <param name="currentQuiz">the list of quiz questions and all of their associated information</param>
        /// <param name="answerList">a list of lists of answer choices that have been randomized by the User</param>
        public static void PrintWholeQuiz(List<QuizCard> currentQuiz, List<List<string>> answerList)
        {
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].questionOutput}\n");

                for (int answerChoice = 0; answerChoice < answerList[questionNumber].Count; answerChoice++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerChoice]}{answerList[questionNumber][answerChoice]}");
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// asks the user if they would like to see the whole quiz
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
        /// outputs the next question in the quiz to the, prompts them to answer it and then checks whether the answer they
        /// entered is right or wrong
        /// </summary>
        /// <param name="currentQuiz">list of quiz questions and all of their associated information</param>
        /// <param name="answerList">list of lists of answer choices that has been randomized</param>
        /// <param name="questionNumber">number of the current quiz question the User is answering</param>
        /// <returns>true or false based on whether or not the user answered correctly</returns>
        public static List<bool> PlayQuiz(List<QuizCard> currentQuiz, List<List<string>> answerList)
        {
            List<bool> rightOrWrong = new List<bool>();
            for (int questionNumber = 0; questionNumber <= currentQuiz.Count - 1; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].questionOutput}\n");
                int correctAnswerIndex = answerList[questionNumber].IndexOf(currentQuiz[questionNumber].correctAnswer);

                foreach (string answer in answerList[questionNumber])
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerList[questionNumber].IndexOf(answer)]}{answer}\n");
                }

                Console.Write("\n");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                rightOrWrong.Add (userInput.Key == Constants.ANSWER_KEYS[correctAnswerIndex]);
            }
            return rightOrWrong;
        }

        /// <summary>
        /// outputs the entire quiz to the user with the individual score for each question and the overall score of
        /// the whole quiz at the bottom
        /// </summary>
        /// <param name="currentQuiz">list containing quiz questions and all of their associated information</param>
        /// <param name="rightOrWrong"> list used to score User during quiz</param>
        /// <param name="answerList">list of lists of answer choices that have been randomized</param>
        public static void PrintQuizScore(List<QuizCard> currentQuiz, List<bool> rightOrWrong, List<List<string>> answerList)
        {
            int numberCorrect = 0;
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].questionOutput}\n");

                for (int answerChoice = 0; answerChoice < answerList[questionNumber].Count; answerChoice++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerChoice]}{answerList[questionNumber][answerChoice]}");
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
        public static bool IsPlayQuizAgain()
        {
            Console.WriteLine("Would you like to take your quiz again?");
            Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
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
            Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool continuePlaying = (userInput.Key == Constants.USER_YES_CHOICE);
            return continuePlaying;
        }
    }
}