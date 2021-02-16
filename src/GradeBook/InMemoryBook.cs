using System;
using System.Collections.Generic;

namespace GradeBook
{

    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.Add(grade);
            };

            return statistics;
        }

        private List<double> grades;
        public const string CATEGORY = "Science";
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        /// <exception cref="ArgumentException"></exception>
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($" Invalid {nameof(grade)}");
            }
        }

    }
}