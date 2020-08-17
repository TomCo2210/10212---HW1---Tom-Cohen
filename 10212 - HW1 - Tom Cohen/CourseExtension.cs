namespace _10212___HW1___Tom_Cohen
{
    internal static class CourseExtension
    {
        public static string ShowGrade(this Course course, int index)
        {
            return course[index] != -1 ? "" + course[index] : "";
        }
    }
}