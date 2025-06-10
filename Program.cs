using System.Text.RegularExpressions;

namespace StudentRegistration
{
    public class Student
    {
        public string? Name;
        public int Age;
        public double Grade;
        //returns TRUE if 'Grade' >= 7
        public bool IsApproved()
        {
            return Grade >= 7;
        }
    }
    public class StudentManager
    {
        List<Student> students = new List<Student>(); //students list

        //request name, age and grade in the console. - Used for adding a student to the list 'students'
        public void RegisterStudent()
        {
            Console.Write("\nStudent name: ");
            string? name = Console.ReadLine();
            Console.Write("\nStudent age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Enter a valid age: ");
            }
            Console.Write("\nStudent grade: ");
            double grade;
            while (!double.TryParse(Console.ReadLine(), out grade))
            {
                Console.WriteLine("Enter a valid grade: ");
            }
            students.Add(new Student { Name = name, Age = age, Grade = grade });
        }
        //display approved students (grade >= 7) and their grade
        public void ListApproved()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
            var approved = students.Where(s => s.IsApproved()).ToList();
            if (approved.Count == 0)
            {
                Console.WriteLine("No students approved.");
                return;
            }
            foreach (var student in approved)
            {
                Console.WriteLine($"{student.Name} - Grade: {student.Grade} (Approved)");
            }
        }
        //list the failed students and their grade
        public void ListFailed()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
            var failed = students.Where(s => s.Grade < 7).ToList();
            if (failed.Count == 0)
            {
                Console.WriteLine("No students failed.");
                return;
            }
            foreach (var student in failed)
            {
                Console.WriteLine($"{student.Name} - Grade: {student.Grade} (Failed)");
            }
        }
        //display the list grade average
        public void DisplayClassAvg()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered to calculate the average.");
                return;
            }
            double classAvg = students.Average(a => a.Grade);
            Console.WriteLine($"Class grade average: {classAvg:F2}");
        }
        //list adult students from the list
        public void ListAdultStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
            var adults = students.Where(s => s.Age > 18).ToList();
            if (adults.Count == 0)
            {
                Console.WriteLine("No adult students.");
                return;
            }
            foreach (var student in adults)
            {
                Console.WriteLine($"{student.Name} - Age: {student.Age}");
            }
        }
        //list underage students from the list
        public void ListUnderageStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
            var adults = students.Where(s => s.Age < 18).ToList();
            if (adults.Count == 0)
            {
                Console.WriteLine("No underage students.");
                return;
            }
            foreach (var student in adults)
            {
                Console.WriteLine($"{student.Name} - Age: {student.Age}");
            }
        }
        //display groups of students based on their age
        public void GroupByAge()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered yet.");
                return;
            }
            var grouped = students.GroupBy(a => a.Age);
            Console.WriteLine("\n===== Students Grouped by Age =====");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Age: {group.Key} ({group.Count()} students)");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.Name} - Grade: {student.Grade}");
                }
            }
        }

    }
    
    public class Program
    {
        static void Main()
        {
            StudentManager manager = new StudentManager();
            bool _continue = true;
            while (_continue)
            {
                string menu = """

                === Student Menu ===
                1. Register student
                2. List approved students
                3. List failed students
                4. Show class average
                5. List adult students
                6. List underage students
                7. Group students by age
                8. Exit
                Choose an option: 
                """;
                Console.Write(menu);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Please, enter a valid option: ");
                }
                switch (choice)
                {
                    case 1: manager.RegisterStudent(); break;
                    case 2: manager.ListApproved(); break;
                    case 3: manager.ListFailed(); break;
                    case 4: manager.DisplayClassAvg(); break;
                    case 5: manager.ListAdultStudents(); break;
                    case 6: manager.ListUnderageStudents(); break;
                    case 7: manager.GroupByAge(); break;
                    case 8: _continue = false; Console.WriteLine("\nEnding program..."); break;
                    default: Console.WriteLine("Invalid option."); break;

                }
            }
        }
    }
}