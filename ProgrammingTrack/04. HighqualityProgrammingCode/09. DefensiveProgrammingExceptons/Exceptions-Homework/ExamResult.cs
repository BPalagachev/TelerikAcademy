using System;

public class ExamResult
{
    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade must be a value that is greather or equal then 0!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimal grade cannnot be a negative number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Max grade must be bigger number then min grade!");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentException("Comments cannot be null or empty  string!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
