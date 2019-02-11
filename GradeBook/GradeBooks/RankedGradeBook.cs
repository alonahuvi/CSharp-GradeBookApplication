using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook: BaseGradeBook
    {
        static int MIN_NUMBER_OF_STUDENTS = 5;
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < MIN_NUMBER_OF_STUDENTS)
            {
                throw new InvalidOperationException("Number of students is under the minimum required");
            }
            int letterIndex = (GetGradeRank(averageGrade) * 100 / 20) / Students.Count;
            switch (letterIndex)
            {
                case 0: return 'A';
                case 1: return 'B';
                case 2: return 'C';
                case 3: return 'D';
                case 4: return 'F';
                default:
                    throw new Exception("Invalid grade? " + averageGrade + ", index " + letterIndex);
            }
        }

        private int GetGradeRank(double grade)
        {
            int countHigherGrades = 0;
            foreach (var student in base.Students)
            {
                if (student.AverageGrade > grade)
                {
                    countHigherGrades++;
                }
            }
            return countHigherGrades;
        }
    }
}
