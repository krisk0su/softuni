using System;
using System.Collections.Generic;
using System.Text;


public class Department
{
    private string name;
    //getter setter
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }

    }

    public List<Employee> employees = new List<Employee>();

    //constructor 
    public Department(string name)
    {
        this.Name = name;
    }
    

    //addMethod
    public void AddEmployee(Employee employee)
    {
        this.employees.Add(employee);
    }

  


}

