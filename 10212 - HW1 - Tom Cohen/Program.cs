using System;
using System.Collections.Generic;
using System.Linq;


namespace _10212___HW1___Tom_Cohen
{
    internal static class Program
    {
        private static void Main()
        {
            var coursesList = InitCoursesList();
            Delegate<Course> filterDelegate;

            Console.WriteLine("List of courses: \n");
            Print(coursesList);
            Console.WriteLine();

            Menu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "P":
                case "p":
                    filterDelegate = course =>
                        course.CourseRepresentingStudent.Grades.Count > 0 && course.CourseRepresentingStudent.Grades.Average() >= 60;
                    break;
                case "#":
                    filterDelegate = course => course.CourseName.Equals("C#");
                    break;
                default:
                    filterDelegate = course => course.CourseRepresentingStudent.Grades.Contains(100);
                    break;
            }
            var q1Result = Q1(coursesList, filterDelegate).ToList();
            var q1InverseResult = coursesList.Except(q1Result).ToList();
            PrintQ1(q1Result, q1InverseResult);

            Console.WriteLine();
            Console.WriteLine("coursesList[1].ShowGrade(0):");
            Console.WriteLine(coursesList[1].ShowGrade(0));
            Console.WriteLine();
            Console.WriteLine("coursesList[2].ShowGrade(3):");
            Console.WriteLine(coursesList[2].ShowGrade(3));
            Console.WriteLine();

            var q2Result = Q2(coursesList).ToList();
            PrintQ2(q2Result);
        }


        private static IEnumerable<T> Q1<T>(IEnumerable<T> list, Delegate<T> filterDelegate)
        {
            return from item in list where filterDelegate(item) select item;
        }

        private static IEnumerable<Course.Student> Q2(List<Course> coursesList)
        {
            return from course in coursesList
                   let gradesGreaterThan60 = course.CourseRepresentingStudent.Grades.FindAll(grade => grade >= 60)
                   where gradesGreaterThan60.Count > 0 && gradesGreaterThan60.Average() >= 90
                   select course.CourseRepresentingStudent;
        }

        private delegate bool Delegate<in T>(T obj);

        private static void Menu()
        {
            Console.WriteLine("Press P / p : Those who passed in average and those who did not :");
            Console.WriteLine("Press # : C# Courses, and other courses:");
            Console.WriteLine("Any other key : Courses with student who have at least one grade of 100, all the other courses:");
        }

        private static void Print<T>(IEnumerable<T> a)
        {
            Console.WriteLine(string.Join("\n", a));
        }

        private static List<Course> InitCoursesList()
        {
            var coursesList = new List<Course>
            {
                new Course
                {
                    CourseName = "C#",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Jojo",
                        Grades = new List<int> { 10, 20, 100 }
                    }
                },
                new Course
                {
                    CourseName = "C",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Bambi",
                        Grades = new List<int> { 99 }
                    }
                },
                new Course
                {
                    CourseName = "Java",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Bambi",
                        Grades = new List<int>()
                    }
                },
                new Course
                {
                    CourseName = "C#",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Jojo",
                        Grades = new List<int> { 10, 20, 30, 40 }
                    }
                },
                new Course
                {
                    CourseName = "Java",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Lady Gaga",
                        Grades = new List<int> { 100, 99, 1, 100, 100 }
                    }
                },
                new Course
                {
                    CourseName = "Java",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Tami",
                        Grades = new List<int> { 60, 70, 80, 1 }
                    }
                },
                new Course
                {
                    CourseName = "SQL",
                    CourseRepresentingStudent = new Course.Student
                    {
                        Name = "Lady Gaga",
                        Grades = new List<int> { 50 }
                    }
                }
            };

            return coursesList;
        }

        private static void PrintQ1(IEnumerable<Course> resultList, IEnumerable<Course> inverseList)
        {
            Console.WriteLine("Q1 Results:");
            Console.WriteLine("False");
            Console.WriteLine("------------");
            Print(inverseList);
            Console.WriteLine();
            Console.WriteLine("True");
            Console.WriteLine("------------");
            Print(resultList);
        }

        private static void PrintQ2(List<Course.Student> q2Result)
        {
            Console.WriteLine("Q2 Results:");
            q2Result.ForEach(student =>
            {
                Console.WriteLine($"{{ Name = {student.Name}, List = {string.Join(" ", student.Grades)} }}");
            });
        }
    }
}
