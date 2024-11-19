using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

Student student = new Student();
Console.WriteLine(student.ToShortString());
student.Educ = Education.SecondEducation;
Console.WriteLine(student[Education.Specialist] + " " + student[Education.Bachelor] + " " + student[Education.SecondEducation]);
student.StudentData = new Person("Алексей", "Серый", new DateTime(2007, 5, 5));
student.GroupNumber = 2;
Exam[] exams =
{
    new Exam("УПП", 6, new DateTime(2022, 4, 4)),
    new Exam("ТПО", 7, new DateTime(2023, 7, 2))
};
student.Exams = exams;
Console.WriteLine(student);
student.AddExams(new Exam("РСПО", 8, new DateTime(2022, 4, 5)), new Exam("КПЯП", 9, new DateTime(2024, 2, 2)));
Console.WriteLine(student);