using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{
    

    public string name;

    public decimal salary;

    public string department;

    public string position;

    //optional
    public string email;
    //optional
    public int age;

   //empty contructor
    public Employee()
    {
       
    }
    //constructor with the must
    public Employee(string name, decimal salary, string position, string department )
    {
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.position = position;

        this.email = "“n/a";
        this.age = -1;
    }
    //constructor + age
    public Employee(string name, decimal salary, string position, string department, int age)
    {
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.position = position;

        this.email = "“n/a";
        this.age = age;
    }

    //constructor + email
    public Employee(string name, decimal salary, string position, string department, string email)
    {
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.position = position;

        this.email = email;
        this.age = -1;
    }

    //full construcotor
    public Employee(string name, decimal salary, string position, string department, string email, int age )
    {
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.position = position;

        this.email = email;
        this.age = age;
    }



}

