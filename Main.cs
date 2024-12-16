using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

Person p1 = new Person();
Person p2 = new Person();
if (p1 == p2)
{
    Console.WriteLine(p1.ToShortString());
    Console.WriteLine(p1.GetHashCode());
}
if (p2 != p1)
{
    Console.WriteLine(p2.ToShortString());
}

Console.WriteLine($"Ссылки на объекты равны: {object.ReferenceEquals(p1, p2)}");
Student student = new Student();
Console.WriteLine(student.ToShortString());
student.Educ = Education.SecondEducation;
Console.WriteLine(student[Education.Specialist] + " " + student[Education.Bachelor] + " " + student[Education.SecondEducation]);
student.StudentData = new Person("Алексей", "Серый", new DateTime(2007, 5, 5));
student.GroupNumber = 291;
ArrayList exams = new ArrayList();
exams.Add(new Exam("УПП", 2, new DateTime(2022, 4, 4)));
exams.Add(new Exam("ТРПО", 7, new DateTime(2023, 7, 2)));
Exam[] exams2 = { new Exam("КПЯ", 10, new DateTime(2025, 1, 1)) };
student.Exams = exams;
student.AddExams(exams2);
Exam exam1 = new Exam();
Console.WriteLine(exam1);
Console.WriteLine(student);

Console.WriteLine(student.StudentData);

Student student2 = (Student)student.DeepCopy();

student.GroupNumber++;

Console.WriteLine(student);
Console.WriteLine(student2);

ArrayList students = new ArrayList();
students.Add(student);
students.Add(student2);

try
{
    student.GroupNumber = 1;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine("\nСписок всех зачетов и экзаменов:");
    foreach (Student item in students)
    {
        foreach (var exam in item.Exams)
        {
            Console.WriteLine(exam);
        }
    }

    Console.WriteLine("\nСписок всех зачетов и экзаменов(С оценкой 3+):");
    foreach (Student item in students)
    {
        foreach (Exam exam in item.Exams)
        {
            if(exam.Mark >3)
                Console.WriteLine(exam);
        }
    }
}
