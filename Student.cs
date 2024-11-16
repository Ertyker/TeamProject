using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Student
    {
        private Person studentData;
        private Education educ;
        private int groupNumber;
        private Exam[] exams = new Exam[20];
        private int indexForAddExams = 0;
        public Student() : this(new Person("Петя", "Петров", new DateTime(2007, 2, 2)), Education.Specialist, 4) { }
        public Student(Person studentData, Education educ, int groupNumber)
        {
            this.studentData = studentData;
            this.educ = educ;
            this.groupNumber = groupNumber;
        }
        public Person StudentData
        {
            get => studentData;
            set => studentData = value;
        }
        public Education Educ
        {
            get => educ;
            set => educ = value;
        }
        public Exam[] Exams
        {
            get => exams;
            set => exams = value;
        }
        public void AddExams(params Exam[] exams)
        {
            for (int i = 0; i < exams.Length; i++)
            {
                if (indexForAddExams == exams.Length - 1)
                {
                    exams[indexForAddExams++] = exams[i];
                }
                else
                {
                    Console.WriteLine("Индекс за пределами массива");
                    break;
                }
            }
        }
    }
    enum Education
    {
        Specialist,
        Вachelor,
        SecondEducation
    }
}
