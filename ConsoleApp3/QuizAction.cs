namespace Quiz_Maker
{
    internal class QuizAction
    {
        /// <summary>
        /// represents the 2 options a User has that pertain to loading quiz data into the Program (they can create it
        /// or load it from a file)
        /// </summary>
        public enum QuizCreation
        {
            Make,
            Load,
        }

        public enum QuizOptions
        {
            Edit,
            Add,
            Take
        }
    }
}
