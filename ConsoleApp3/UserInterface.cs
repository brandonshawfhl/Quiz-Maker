using System.IO;
using System.Xml.Serialization;

namespace Quiz_Maker
{
    internal class UserInterface
    {
        enum QuizAction
        {
            Take,
            Save,
            Load
        }

        enum TakeQuiz
        {
            Question,
            RightAnswer,
            WrongAnswers
        }


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
            string rightAnswer = Console.ReadLine();
            return rightAnswer;
        }

        public static List<string> PromptForWrongAnswers()
        {
            bool moreWrongAnswers = true;
            List<string> wrongAnswerList = new List<string>();
            while (moreWrongAnswers)
            {
                Console.WriteLine("Please enter an incorrect answer that will be listed as one of the choices for this question.");
                string wrongAnswer = Console.ReadLine();
                wrongAnswerList.Add(wrongAnswer);

                Console.WriteLine("\n");
                Console.WriteLine($"Would you like to create more wrong answers for this question?");
                Console.WriteLine($"({Constants.USER_YES_CHOICE} or press any other key to continue.)\n");

                ConsoleKeyInfo userInput = Console.ReadKey(true);
                moreWrongAnswers = (userInput.Key == Constants.USER_YES_CHOICE);
            }
            return wrongAnswerList;
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

        public static void QuizOptions(List<QuestionAndAnswers> questionAndAnswersList)
        {
            QuizAction choice = new QuizAction();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
            List<QuestionAndAnswers> quizActionList = new List<QuestionAndAnswers>();
            var path = @"C:\tmp\questionAndAnswersList.xml";
            switch (choice)
            {
                case QuizAction.Take:
                    Console.WriteLine();
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                        break;


                case QuizAction.Save:
                    path = Console.ReadLine();
                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, questionAndAnswersList);
                    }
                    break;

                case QuizAction.Load:
                    path = Console.ReadLine();
                    using (FileStream file = File.OpenRead(path))
                    {
                        quizActionList = serializer.Deserialize(file) as List<QuestionAndAnswers>;
                    }
                    break;
            }
        }

        public static int PromptForQuizAction()
        {
            Console.WriteLine("\n");
            Console.WriteLine("What would you like to do?((0) - Take quiz, (1) - Save quiz and (2) - Load a previously saved quiz");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
