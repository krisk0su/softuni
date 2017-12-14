using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace average_Grades_su
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int numberStudents = int.Parse(Console.ReadLine());
            List<student> students = new List<student>();

            for (int i = 0; i < numberStudents; i++)
            {
                string[] inputTokens = Console.ReadLine().Split();
                string studentName = inputTokens[0];

                List<double> grades = new List<double>();
                for (int j = 1; j < inputTokens.Length; j++)
                {
                    double grade = double.Parse(inputTokens[j]);
                    grades.Add(grade);
                }

                student student = new student();
                student.Name = studentName;
                student.ListOfGrades = grades;

                students.Add(student);

            }

            foreach (student student in students.Where(s => s.numAvr >= 5).OrderBy(s => s.Name)
                .ThenByDescending(s => s.numAvr))
            {
                Console.WriteLine("{0} -> {1:F2} ", student.Name, student.numAvr);

            }

         

        }
    }

    class student
    {
        public string Name { get; set; }

        public List<double> ListOfGrades { get; set; }

        public double numAvr
        {
            get
            {
                return ListOfGrades.Average();
            }
        }
    }
}
