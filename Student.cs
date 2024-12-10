using System;
using System.Collections;
using System.Collections.Generic;

namespace TeamProject
{
    internal class Student : Person, IDateAndCopy
    {
        private Person studentData;
        private Education educ;
        private int groupNumber;
        private ArrayList examsList;
        private int examsCount = 0;
        private ArrayList testsList;

        public Student() : this(new Person("Петя", "Петров", new DateTime(2007, 2, 2)), Education.Specialist, 4)
        {
            examsList = new ArrayList();
            testsList = new ArrayList();
        }
        public Student(Person studentData, Education educ, int groupNumber)
        {
            this.studentData = studentData;
            this.educ = educ;
            this.groupNumber = groupNumber;
            examsList = new ArrayList();
            testsList = new ArrayList();
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
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentException("У вас ошибка");
                }
                groupNumber = value;
            }
        }
        public ArrayList Exams
        {
            get => examsList;
            set
            {
                examsList.Clear();
                examsList.AddRange(value);
                examsCount = value.Count;
            }
        }
        public double AvgMark
        {
            get
            {
                int sum = 0;
                if (examsCount > 0)
                {
                    for (int i = 0; i < Exams.Count; i++)
                    {
                        Exam exam = (Exam)Exams[i];
                        sum += exam.Mark;
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
                return Educ == educ;
            }
        }
        public void AddExams(params Exam[] exms)
        {
            for (int i = 0; i < exms.Length; i++)
            {
                examsList.Add(exms[i]);
                examsCount++;
            }
        }
        public override string ToString()
        {
            string ex = "";
            for (int i = 0; i < Exams.Count; i++)
            {
                if (examsList[i] != null) ex += examsList[i].ToString() + "\n";
            }
            return $"Данные студента: {studentData} Форма обучения: {educ} Номер группы: {groupNumber} Список экзаменов:\n{ex}";
        }

        public virtual string ToShortString()
        {
            return $"Данные студента: {studentData} Форма обучения: {educ} Номер группы: {groupNumber} Средний балл: {AvgMark}";
        }

        public object DeepCopy()
        {
            return new Student(this.studentData, this.educ, this.groupNumber)
            {
                examsList = this.examsList
            };
        }

        public IEnumerable<object> GetAllItems()
        {
            foreach (var test in testsList)
            {
                yield return test;
            }

            foreach (var exam in examsList)
            {
                yield return exam;
            }
        }

        public IEnumerable<Exam> GetExamsWithMarkAbove(int threshold)
        {
            foreach (Exam exam in examsList)
            {
                if (exam.Mark > threshold)
                {
                    yield return exam;
                }
            }
        }
    }
}

