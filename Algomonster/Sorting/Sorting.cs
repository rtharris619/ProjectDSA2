namespace ProjectDSA2.Algomonster.Sorting;

public class Sorting
{
    public static void TestSorting()
    {
        List<int> nums = new List<int> { 40, 100, 1, 5, 25, 10 };
        nums.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine(string.Join(" ", nums));
    }

    public class Student
    {
        string name;
        int mathGrade;
        int englishGrade;

        public Student(string name, int mathGrade, int englishGrade)
        {
            this.name = name;
            this.mathGrade = mathGrade;
            this.englishGrade = englishGrade;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int GetTotalScore()
        {
            return this.mathGrade + this.englishGrade;
        }
    }

    public static void PrintStudentNames(List<Student> students)
    {
        Console.WriteLine(string.Join(" ", students.Select(s => s.Name)));
    }

    public static void PrintSortedStudents(List<Student> students)
    {
        // ascending order
        students.Sort((a, b) => a.GetTotalScore().CompareTo(b.GetTotalScore()));
        PrintStudentNames(students);

        // descending order
        students.Sort((a, b) => b.GetTotalScore().CompareTo(a.GetTotalScore()));
        PrintStudentNames(students);
    }

    public static void TestSortingStudents()
    {
        List<Student> students = [
            new Student("Sally", 50, 80),
            new Student("Moon", 68, 22),
            new Student("Cony", 36, 71),
            new Student("Leonard", 90, 75),
        ];

        PrintSortedStudents(students);
    }

    public static void Driver()
    {
        TestSortingStudents();
    }
}
