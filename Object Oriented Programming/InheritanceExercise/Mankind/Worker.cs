using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private double weeklySalary;

    public double WeeklySalary
    {
        get { return this.weeklySalary; }

        set
        {
            if (value <= 10)
            {
                throw  new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            weeklySalary = value;
        }
    }

    private double hours;

    public double Hours
    {
        get { return hours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            hours = value;
        }
    }

    private double salaryPerHour()
    {
        var res =  WeeklySalary / (Hours * 5) ;

        return res;
    }
    public Worker(string firstName, string lastName, double weeklySalary, double hoursPerDay) : base(firstName, lastName)
    {
        WeeklySalary = weeklySalary;

        Hours = hoursPerDay;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Week Salary: {WeeklySalary:f2}");
        sb.AppendLine($"Hours per day: {Hours:f2}");
        sb.AppendLine($"Salary per hour: {salaryPerHour():f2}");

        return sb.ToString();
    }
}

