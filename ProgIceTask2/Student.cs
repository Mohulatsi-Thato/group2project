using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgIceTask2
{
    public class Student
    {
        private string Name { get; set; }
        private double Test1 { get; set; }
        private double Test2 { get; set; }

        public Student(string name, double test1, double test2)
        {
            if (test1 < 0 || test1 > 100 || test2 < 0 || test2 > 100)
            {
                throw new ArgumentOutOfRangeException("Test scores must be between 0 and 100.");
            }

            Name = name;
            Test1 = test1;
            Test2 = test2;
        }

        public double ComputeAverage()
        {
            try
            {
                return (Test1 + Test2) / 2;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while computing the average: " + ex.Message);
            }
        }

        public override string ToString()
        {
            double average = ComputeAverage();
            return $"Name: {Name}, Test1: {Test1}, Test2: {Test2}, Average: {average:F2}";
        }
    }
}
