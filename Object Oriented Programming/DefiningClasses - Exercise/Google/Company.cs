using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    public string companyName;

    public string department;

    public double salary;


    public Company(string name, string department, double salary)
    {
        this.companyName = name;

        this.department = department;

        this.salary = salary;

    }

    public override string ToString()
    {
        if (companyName.Length==0)
        {
            return "";
        }

        return $"{companyName} {department} {salary:F2}";
    }
}

