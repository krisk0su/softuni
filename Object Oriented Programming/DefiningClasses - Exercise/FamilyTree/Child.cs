using System;
using System.Collections.Generic;
using System.Text;

public class Child
{
    public string name;

    public string date;

    public Child(string input)
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
    }
}
