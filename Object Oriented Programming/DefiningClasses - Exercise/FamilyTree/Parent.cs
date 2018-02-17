using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    public string name;

    public string date;

    public List<Child> children;

    public Parent(string input)
    {

        if (input.Contains("/"))
        {
            this.date = input;
            name = "";
        }
        else
        {
            this.name = input;
            date = "";
        }

       children = new List<Child>();
    }
}

