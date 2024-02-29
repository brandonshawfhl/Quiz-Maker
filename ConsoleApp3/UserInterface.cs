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
                Console.Write("\n");
                Console.WriteLine("Is this answer correct?");
                Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
                ConsoleKeyInfo isCorrectInput = Console.ReadKey(true);
                potentialAnswer.isCorrect = (isCorrectInput.Key == Constants.USER_YES_CHOICE);
                potentialAnswers.Add(potentialAnswer);
                tooManyAnswers = potentialAnswers.Count >= Constants.CHOICE_LIMIT;


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
        /// asks User to provide a number that determines what they would like to do in this program
        /// </summary>
        /// <returns>the choice they made in the form of an enum</returns>
        public static QuizAction.QuizOptions PromptQuizAction()
        {
            QuizAction.QuizOptions quizChoice;
            while (true)
            {
                Console.WriteLine("What would you like to do?(Enter 0 to make a quiz and 1 to load a quiz. If a quiz has");
                Console.WriteLine("already been made or loaded you may also enter 2 to edit the current quiz, 3 to add");
                Console.WriteLine("to a quiz or 4 to take the current quiz. Once you have entered the corresponding");
                Console.WriteLine("number, press enter to continue.\n");
                string quizChoiceConversion = Console.ReadLine();
                quizChoice = (QuizAction.QuizOptions)Enum.Parse(typeof(QuizAction.QuizOptions), quizChoiceConversion);
                Console.Clear();
                switch (quizChoice)
                {
                    case QuizAction.QuizOptions.Make:
                        break;

                    case QuizAction.QuizOptions.Load:
                        break;

                    case QuizAction.QuizOptions.Edit:
                        break;

                    case QuizAction.QuizOptions.Add:
                        break;

                    case QuizAction.QuizOptions.Take:
                        break;

                    default:
                        Console.WriteLine("Invalid entry. Please try again.\n");
                        continue;
                }
                break;
            }
            return quizChoice;
        }

        /// <summary>
        /// Asks the user if they would like to create more questions
        /// </summary>
        /// <returns>true or false depedning on the user's answer</returns>
        public static bool PromptMoreQuestions()
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
        public static void PrintQuiz(List<QuizCard> currentQuiz)
        {
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{questionNumber + 1}. {currentQuiz[questionNumber].question}\n\n");

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].answerChoices.Count; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}  " +
                        $"{currentQuiz[questionNumber].answerChoices[answerNumber].answer}\n");
                }
                Console.WriteLine("\n\n");
            }
        }

        /// <summary>
        /// asks the user if they would like to see the whole quiz
        /// </summary>
        /// <returns>returns true or false based on the user's answer</returns>
        public static bool PromptSeeQuiz()
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
                Console.WriteLine($"{questionNumber + 1}. {currentQuiz[questionNumber].question}\n\n");

                for (int answerNumber = 0; answerNumber <= currentQuiz[questionNumber].answerChoices.Count - 1; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}  " +
                        $"{currentQuiz[questionNumber].answerChoices[answerNumber].answer}\n");
                }

                Console.WriteLine("\n\n");
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
        public static void PrintScore(List<QuizCard> currentQuiz, List<int> userAnswers)
        {
            int numberCorrect = 0;
            for (int questionNumber = 0; questionNumber < currentQuiz.Count; questionNumber++)
            {
                Console.WriteLine($"{questionNumber + 1}. {currentQuiz[questionNumber].question}\n");

                for (int answerNumber = 0; answerNumber < currentQuiz[questionNumber].answerChoices.Count; answerNumber++)
                {
                    Console.WriteLine($"{Constants.ANSWER_CHOICES[answerNumber]}  " +
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
        public static bool PromptPlayQuizAgain()
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
        public static bool PromptContinue()
        {
            Console.WriteLine("Would you like to continue?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool continuePlaying = (userInput.Key == Constants.USER_YES_CHOICE);
            return continuePlaying;
        }

        /// <summary>
        /// prompts the User to disclose whether or not they would like to make any changes to their quiz
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptMakeChanges()
        {
            Console.WriteLine("Would you like to make any changes");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool makeChanges = (userInput.Key == Constants.USER_YES_CHOICE);
            return makeChanges;
        }

        /// <summary>
        /// Prompts the User to enter the number of the question they would like to edit
        /// </summary>
        /// <returns>the number of the question the User would like to edit</returns>
        public static int GetQuestionNumber()
        {
            Console.WriteLine("Which question would you like to change?");
            Console.WriteLine("Please enter the number of the question you like to change and then press Enter.\n");
            int questionNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            return questionNumber;
        }

        /// <summary>
        /// Prompts the user to disclose whether or not they would like to edit the question specifically
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptEditQuestion()
        {
            Console.WriteLine("Would you like to edit the question itself?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool editQuestion = (userInput.Key == Constants.USER_YES_CHOICE);
            Console.Write("\n");
            return editQuestion;
        }

        /// <summary>
        /// allows the user to edit the question they have previously selected and gives them the tools they need to do it
        /// </summary>
        /// <param name="currentQuiz">list containing quiz questions and all of their associated information</param>
        /// <param name="questionNumber">the number of the question the user has previously selected</param>
        /// <returns></returns>
        public static string EditQuestion(List<QuizCard> currentQuiz, int questionNumber)
        {
            Console.WriteLine($"Editing question number {questionNumber}.");
            Console.WriteLine("Please type the question the way you would like it.");
            Console.WriteLine($"{currentQuiz[questionNumber - 1].question}");
            string questionEdit = Console.ReadLine();
            Console.Write("\n");
            return questionEdit;
        }

        /// <summary>
        /// prompts the User to disclose whether or not they would like to edit any of the answers corresponding with the 
        /// question they have previously selected
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptEditAnswers()
        {
            Console.WriteLine("Would you like to edit any answers for this question?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool editAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            Console.Write("\n");
            return editAnswers;
        }

        /// <summary>
        /// prompts the User to choose which answer they would like to edit
        /// </summary>
        /// <returns>returns the corresponding numer to the answer the User selects</returns>
        public static int GetAnswerNumber()
        {
            Console.WriteLine("Which answer would you like to change?");
            Console.WriteLine("Please enter the letter of the answer you would like to change.");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            int answerNumber = Constants.ANSWER_KEYS.IndexOf(userInput.Key);
            Console.Write("\n");
            return answerNumber;
        }

        /// <summary>
        /// allows the User to edit the answer they have previously selected
        /// </summary>
        /// <param name="currentQuiz">list containing quiz questions and all of their associated information</param>
        /// <param name="questionNumber">the number of the question the User has previously selected</param>
        /// <param name="answerNumber">the corresponding number of the answer the User has previously selected</param>
        /// <returns></returns>
        public static Answer EditAnswer(List<QuizCard> currentQuiz, int questionNumber, int answerNumber)
        {
            Console.WriteLine($"Editing answer {Constants.ANSWER_CHOICES[answerNumber]} in question number {questionNumber}.");
            Console.WriteLine("Please type the answer the way you would like it.");
            Console.WriteLine($"{currentQuiz[questionNumber - 1].answerChoices[answerNumber].answer}");
            Answer answerEdit = new()
            {
                answer = Console.ReadLine()
            };

            Console.Write("\n");
            Console.WriteLine("Is this answer correct?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            answerEdit.isCorrect = (userInput.Key == Constants.USER_YES_CHOICE);
            return answerEdit;
        }

        /// <summary>
        /// prompts the user to disclose whether or not they would like to edit another answer
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptEditAnotherAnswer()
        {
            Console.WriteLine("Would you like to edit another answer?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool editAnswer = (userInput.Key == Constants.USER_YES_CHOICE);
            return editAnswer;
        }

        /// <summary>
        /// prompts the user to disclose whether or not they would like to make more changes to their quiz
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptMoreChanges()
        {
            Console.WriteLine("Would you like to make any more changes");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool makeChanges = (userInput.Key == Constants.USER_YES_CHOICE);
            return makeChanges;
        }

        /// <summary>
        /// prompts the User to disclose whether or not they would like to save the quiz they just created/edited
        /// </summary>
        /// <returns>true or false based on the User's disclosure</returns>
        public static bool PromptSave()
        {
            Console.WriteLine("Would you like to save your quiz?");
            Console.WriteLine($"('{Constants.USER_YES_CHOICE}' or press any other key to continue.)\n");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            bool saveQuiz = (userInput.Key == Constants.USER_YES_CHOICE);
            return saveQuiz;
        }

        /// <summary>
        /// prints message indicating a successfully loaded quiz
        /// </summary>
        public static void PrintSuccessfulLoadMessage()
        {
            Console.WriteLine("Your quiz has been successfully loaded!");
        }

        /// <summary>
        /// ptints message indicating a successfully save quiz
        /// </summary>
        public static void PrintSuccessfulSaveMessage()
        {
            Console.WriteLine("Your quiz has been successfully saved!\n");
        }

        /// <summary>
        /// prints message indicating a failure to load a quiz
        /// </summary>
        public static void PrintFailedLoadMessage()
        {
            Console.WriteLine("Sorry! Your quiz has failed to load!");
        }

        /// <summary>
        /// prints message indicating that the question the User has tried to select does not exist
        /// </summary>
        public static void PrintQuestionDoesntExistMessage()
        {
            Console.WriteLine("This question does not exist. Please try again.");
        }

        /// <summary>
        /// prints a message indicating that the answer the User has tried to select does not exist
        /// </summary>
        public static void PrintAnswerDoesntExistMessage()
        {
            Console.WriteLine("This answer does not exist. Please try again.");
        }

        public static void PrintNoQuizStoredMessage()
        {
            Console.WriteLine("Sorry you do not have any quiz data stored.");
            Console.WriteLine("Please create or load a quiz to continue.");
        }
    }
}