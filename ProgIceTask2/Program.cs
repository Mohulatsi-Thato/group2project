using System.Collections;

namespace ProgIceTask2
{
    internal class Program
    
    {
        static void Main(string[] args)
        {
            ArrayList students = new ArrayList();

            try
            {
                // Adding five valid students
                students.Add(new Student("Alice", 85, 90));
                students.Add(new Student("Bob", 78, 82));
                students.Add(new Student("Charlie", 92, 88));
                students.Add(new Student("Diana", 67, 74));
                students.Add(new Student("Ethan", 100, 95));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error creating student: " + ex.Message);
            }

            Console.WriteLine("Student Records:");
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nStatistics:");
            DetermineStats(students);
        }

        static void DetermineStats(ArrayList students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to evaluate.");
                return;
            }

            Student highestStudent = null;
            Student lowestStudent = null;
            double highest = double.MinValue;
            double lowest = double.MaxValue;
            double total = 0;

            foreach (Student student in students)
            {
                double avg = student.ComputeAverage();

                if (avg > highest)
                {
                    highest = avg;
                    highestStudent = student;
                }

                if (avg < lowest)
                {
                    lowest = avg;
                    lowestStudent = student;
                }

                total += avg;
            }

            double overallAverage = total / students.Count;

            Console.WriteLine($"Highest Average: {highest:F2} (Student: {highestStudent.ToString()})");
            Console.WriteLine($"Lowest Average: {lowest:F2} (Student: {lowestStudent.ToString()})");
            Console.WriteLine($"Overall Average of Class: {overallAverage:F2}");
        }
    }
}
