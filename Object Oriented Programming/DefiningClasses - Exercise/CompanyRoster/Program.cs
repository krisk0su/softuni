using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CompanyRoster
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var company = new List<Department>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var employee = new Employee();
                
                if (tokens.Length==4)
                {
                    var name = tokens[0];
                    var salary = decimal.Parse(tokens[1]);
                    var position = tokens[2];
                    var department = tokens[3];

                    //create the employee
                    var e = new Employee(name, salary, position, department);


                    employee = e;
                }
                else if (tokens.Length==5 && tokens[4].Contains("@"))
                {
                    var name = tokens[0];
                    var salary = decimal.Parse(tokens[1]);
                    var position = tokens[2];
                    var department = tokens[3];
                    var email = tokens[4];

                    //create the employee
                    var e = new Employee(name, salary, position, department, email);


                    employee = e;
                }
                else if (tokens.Length == 5 && !tokens[4].Contains("@"))
                {
                    var name = tokens[0];
                    var salary = decimal.Parse(tokens[1]);
                    var position = tokens[2];
                    var department = tokens[3];
                    var age = int.Parse(tokens[4]);

                    //create the employee
                    var e = new Employee(name, salary, position, department, age);


                    employee = e;
                }
                else if (tokens.Length==6)
                {
                    var name = tokens[0];
                    var salary = decimal.Parse(tokens[1]);
                    var position = tokens[2];
                    var department = tokens[3];
                    var email = tokens[4];
                    var age = int.Parse(tokens[5]);

                    //create the employee
                    var e = new Employee(name, salary, position, department, email, age);


                    employee = e;
                }

                //checkIfDepExists
                if (!company.Any(x=> x.Name==tokens[3]))
                {   
                    var department = new Department(tokens[3]);
                    company.Add(department);
                }

                var dep = tokens[3];
                var index = company.FindIndex(x => x.Name.Equals(dep));

                company[index].AddEmployee(employee);
                
            }

            var highestSalary = company.OrderByDescending(x => x.employees.Sum(z => z.salary) / x.employees.Count)
                .First();

            Console.WriteLine($"Highest Average Salary: {highestSalary.Name}");
            foreach (var person in highestSalary.employees.OrderByDescending(x=> x.salary))
            {
                Console.WriteLine($"{person.name} {person.salary:F2} {person.email} {person.age}");
            }
        }
    }
}
