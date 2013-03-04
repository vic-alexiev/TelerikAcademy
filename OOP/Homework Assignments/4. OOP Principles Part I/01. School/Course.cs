using System;

public class Course : IAnnotation
{
    public string Title { get; private set; }

    public int Lectures { get; private set; }

    public int Exercises { get; private set; }

    public string Tag { get; set; }

    public Course(string title, int lectures, int exercises)
    {
        if (String.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Course title cannot be null or empty.");
        }

        if (lectures < 0)
        {
            throw new ArgumentException("Lectures cannot be less than 0.");
        }

        if (exercises < 0)
        {
            throw new ArgumentException("Exercises cannot be less than 0.");
        }

        this.Title = title;
        this.Lectures = lectures;
        this.Exercises = exercises;
    }

    public override string ToString()
    {
        return String.Format("{0}: {1} lectures, {2} exercises", this.Title, this.Lectures, this.Exercises);
    }
}
