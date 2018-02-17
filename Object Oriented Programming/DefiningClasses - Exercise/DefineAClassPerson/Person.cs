using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { name = value; }
    }
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person()
    {
        this.name = "No name";

        this.age = 1;
    }

    public Person(int age)
    {
        this.name = "No name";

        this.age = age;
    }

    public Person(int age, string name)
    {
        this.name = name;

        this.age = age;
    }
}

