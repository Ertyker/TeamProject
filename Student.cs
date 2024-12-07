using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Student : Person, IDateAndCopy
    {
        private Person studentData;
        private Education educ;
        private int groupNumber;
        private Exam[] exams = new Exam[10];
        private int examsCount = 0;

        public Student() : this(new Person("Петя", "Петров", new DateTime(2007, 2, 2)), Education.Specialist, 4) { exams = new Exam[10]; }
        public Student(Person studentData, Education educ, int groupNumber)
        {
            this.studentData = studentData;
            this.educ = educ;
            this.groupNumber = groupNumber;
            exams = new Exam[10];
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
        public int GroupNumber
        {
            get => groupNumber;
            set => groupNumber = value;
        }
        public Exam[] Exams
        {
            get => exams;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    exams[i] = value[i];
                }
                examsCount += value.Length;
            }
        }
        public double AvgMark
        {
            get
            {
                int sum = 0;
                if (examsCount > 0)
                {
                    for (int i = 0; i < Exams.Length; i++)
                    {
                        sum += Exams[i].Mark;
                    }
                    return (double)sum / examsCount;
                }
                return 0;
            }
        }
        public bool this[Education educ]
        {
            get
            {
                return Educ == educ ? true : false;
            }
        }
        public void AddExams(params Exam[] exms)
        {
            for (int i = 0; i < exms.Length; i++)
            {
                if (examsCount < Exams.Length)
                {
                    exams[examsCount++] = exms[i];
                }
                else
                {
                    Console.WriteLine("Индекс за пределами массива");
                    break;
                }
            }
        }
        public override string ToString()
        {
            string ex = "";
            for (int i = 0; i < Exams.Length; i++)
            {
                if (exams[i] != null) ex += exams[i] + "\n";
            }
            return $"Данные студента: {studentData} Форма обучения: {educ} Номер группы: {groupNumber} Список экзаменов:\n{ex}";
        }
        public virtual string ToShortString()
        {
            return $"Данные студента: {studentData} Форма обучения: {educ} Номер группы: {groupNumber} Средний балл: {AvgMark}";
        }

        public object DeepCopy()
        {
            return this;
        }
    }
}