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
        /// prompts the User for an answer to be used as a choice for the question they are creating and then asks 
        /// if the answer is correct or not
        /// </summary>
        /// <returns>a list of AnswerPairs that will be used as choices for the current question</returns>
        public static List<Answer> PromptForAnswers()
        {
            bool tooManyAnswers;
            List<Answer> potentialAnswers = new();
            bool moreWrongAnswers;

            for (int answerNumber = 0; answerNumber < Constants.CHOICE_LIMIT; answerNumber++)
            {
                Answer potentialAnswer = new();
                int choicesLeft = Constants.CHOICE_LIMIT - answerNumber;
                Console.WriteLine("Please enter an answer that will be listed as one of the choices for this question.");
                Console.WriteLine($"You have {choicesLeft} more choices.\n");
                potentialAnswer.answer = Console.ReadLine();
                Console.WriteLine("\n");
                Console.WriteLine("Is this answer correct?");
                Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
                Console.Write("\n");
                ConsoleKeyInfo isCorrectInput = Console.ReadKey(true);
                potentialAnswer.isCorrect = (isCorrectInput.Key == Constants.USER_YES_CHOICE);
                potentialAnswers.Add(potentialAnswer);
                tooManyAnswers = potentialAnswers.Count >= Constants.CHOICE_LIMIT;
                Console.Write("\n");

                if (tooManyAnswers)
                {
                    Console.WriteLine("You have reached the answer choice limit for this question.\n");
                    break;
                }

                Console.WriteLine($"Would you like to create more answers for this question?");
                Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
                Console.Write("\n");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);

                if (moreWrongAnswers == false)
                {
                    break;
                }
            }
            return potentialAnswers;
        }

        /// <summary>
        /// asks user to provide a number that determines what they would like to do in this program
        /// </summary>
        /// <returns>the choice they made in the form of an enum</returns>
        public static QuizAction.QuizOptions PromptForQuizAction()
        {
            Console.WriteLine("What would you like to do?(Enter 0 to make a quiz, 1 to load a quiz and 2 to save a quiz.)");
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
                    Console.WriteLine("Loading your quiz now!");
                    break;

                case QuizAction.QuizOptions.Save:
                    Console.WriteLine("Saving your quiz now!");
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
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
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
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool moreQuestions = (userInput.Key == Constants.USER_YES_CHOICE);
            return moreQuestions;
        }

        /// <summary>
        /// Prompts the user to answer whether or not they would like to take the quiz currently loaded into the program
        /// </summary>
        /// <returns>true or false that is determined by the User's answer</returns>
        public static bool IsPlayQuiz()
        {
            Console.WriteLine("Would you like to take your current quiz?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool takeQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return takeQuiz;
        }

        /// <summary>
        /// prints the entire quiz for the User to see on the screen
        /// </summary>
        /// <param name="currentQuiz">the list of quiz questions and all of their associated information</param>
        public static void PrintWholeQuiz(List<QuizCard> currentQuiz)
        {
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].question}\n");

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].answerChoices.Count; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}" +
                        $"{currentQuiz[questionNumber].answerChoices[answerNumber].answer}");
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
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool seeQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return seeQuiz;
        }

        /// <summary>
        /// outputs all the questions in the entire quiz 1 at a time, allows the User to answer and then stores the number
        /// of the answer the User has selected
        /// </summary>
        /// <param name="currentQuiz">list of quiz questions and all of their associated information</param>
        /// <returns>a list of numbers that correspond to the User's answer choices</returns>
        public static List<int> PlayQuiz(List<QuizCard> currentQuiz)
        {
            List<int> userAnswers = new();

            for (int questionNumber = 0; questionNumber <= currentQuiz.Count - 1; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].question}\n");

                for (int answerNumber = 0; answerNumber <= currentQuiz[questionNumber].answerChoices.Count - 1; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}" +
                        $"{currentQuiz[questionNumber].answerChoices[answerNumber].answer}\n");
                }

                Console.Write("\n");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                userAnswers.Add(Constants.ANSWER_KEYS.IndexOf(userInput.Key));
            }
            return userAnswers;
        }

        /// <summary>
        /// outputs the entire quiz to the user with the individual score for each question and the overall score of
        /// the whole quiz at the bottom
        /// </summary>
        /// <param name="currentQuiz">list containing quiz questions and all of their associated information</param>
        /// <param name="userAnswers">a list of numbers corresponding to the answers the User has selected for each question</param>
        public static void PrintQuizScore(List<QuizCard> currentQuiz, List<int> userAnswers)
        {
            int numberCorrect = 0;
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{currentQuiz[questionNumber].question}\n");

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].answerChoices.Count; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}" +
                        $"{currentQuiz[questionNumber].answerChoices[answerNumber].answer}");
                    Console.WriteLine("\n");
                }

                if (currentQuiz[questionNumber].answerChoices[userAnswers[questionNumber]].isCorrect == true)
                {
                    Console.WriteLine($"{currentQuiz[questionNumber].answerChoices[userAnswers[questionNumber]].answer} " +
                        $"is correct!\n\n");
                    numberCorrect++;
                }

                else
                {
                    Console.WriteLine($"{currentQuiz[questionNumber].answerChoices[userAnswers[questionNumber]].answer} " +
                        $"is incorrect!\n\n");
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
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
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
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool continuePlaying = (userInput.Key == Constants.USER_YES_CHOICE);
            return continuePlaying;
        }

        public static bool PromptToMakeChanges()
        {
            Console.WriteLine("Would you like to make any changes");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool makeChanges = (userInput.Key == Constants.USER_YES_CHOICE);
            return makeChanges;
        }

        public static int GetQuestionNumber()
        {
            Console.WriteLine("Which question would you like to change?");
            Console.WriteLine("Please enter the number of the question you like to change.");
            int questionNumber = Convert.ToInt32(Console.ReadLine());
            return questionNumber;
        }

        public static bool PromptToEditQuestion()
        {
            Console.WriteLine("Would you like to edit the question itself?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool editQuestion = (userInput.Key == Constants.USER_YES_CHOICE);
            return editQuestion;
        }

        public static string EditQuestion(List<QuizCard> currentQuiz, int questionNumber)
        {
            Console.WriteLine("Please type the question the way you would like instead.");
            Console.WriteLine($"{currentQuiz[questionNumber].question}");
            string questionEdit = Console.ReadLine();
            return questionEdit;
        }

        public static bool PromptToEditAnswers()
        {
            Console.WriteLine("Would you like to edit any answers for this question?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool editAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            return editAnswers;
        }
        
    }
}