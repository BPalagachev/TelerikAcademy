using System;
using System.Diagnostics;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("problemSolved must be a number bigger or equal to zero and smaller or equal to ten");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {

        ExamResult result = null;
        switch (ProblemsSolved)
        {
            case 0:
                result = new ExamResult(2, 2, 6, "Bad result: nothing done.");
                break;
            case 1:
                result = new ExamResult(2, 2, 6, "Bad result: nothing done.");
                break;
            case 2:
                result = new ExamResult(6, 2, 6, "Average result: nothing done.");
                break;
            default:
                throw new InvalidOperationException("Invalid state for this.ProblemSolved. It must be 0, 1 or 2, but it was " + this.ProblemsSolved);
                break;
        }

        Debug.Assert(result != null, "Checking math exam unseccsessfull. Result cannot be null");

        return result;
    }
}
