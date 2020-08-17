using System.Collections.Generic;
using System.Linq;


namespace _10212___HW1___Tom_Cohen
{
    internal class Course
    {
        public string CourseName { get; set; }
        public Student CourseRepresentingStudent { get; set; }

        public override string ToString()
        {
            return $"{CourseName,-10}  {CourseRepresentingStudent}";
        }

        public int this[int index] => CourseRepresentingStudent[index];


        internal class Student
        {
            public string Name { get; set; }
            public List<int> Grades { get; set; }

            public override string ToString()
            {
                return $"{Name,-10}  {GradesString()}";
            }

            private string GradesString()
            {
                return Grades.Aggregate("", (current, grade) => string.Concat(current, $"{grade,3} "));
            }

            public int this[int index]
            {
                get
                {
                    if (0 <= index && index < Grades.Count)
                        return Grades[index];
                    return -1;
                }
            }

        }
    }
}
