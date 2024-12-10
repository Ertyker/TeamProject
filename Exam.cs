using TeamProject;
public enum Education
{
    Specialist,
    Bachelor,
    SecondEducation
}
class Exam : IDateAndCopy
{
    internal string LessonName { get; set; }
    internal int Mark { get; set; }
    internal DateTime DateExam { get; set; }
    public DateTime Date { get; set; }

    public Exam()
    {
        this.LessonName = "TRPO";
        this.DateExam = new DateTime(2024, 12, 23, 12, 00, 00);
        this.Mark = 10;
    }

    public Exam(string lesName, int mark, DateTime dayEx)
    {
        this.Mark = mark;
        this.DateExam = dayEx;
        this.LessonName = lesName;
    }

    public override string ToString()
    {
        return string.Format("Предмет: " + this.LessonName + " Оценка: " + this.Mark + " Дата проведения : " + this.DateExam.ToShortDateString());
    }

    public object DeepCopy()
    {
        return new Exam(this.LessonName, this.Mark, this.DateExam);
    }
}