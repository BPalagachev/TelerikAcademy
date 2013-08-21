namespace _01.School
{
    using System;

    public class School
    {
        private static int nextUniqueStudentNumber = 100000;

        internal int GetUniqueStudentNumber()
        {
            if (nextUniqueStudentNumber > 999999)
            {
                throw new InvalidOperationException("There are no more avaiable students numbers!");
            }

            return nextUniqueStudentNumber++;
        }
    }
}
