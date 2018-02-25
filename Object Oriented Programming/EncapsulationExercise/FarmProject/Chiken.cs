using System;
using System.Collections.Generic;
using System.Text;


public class Chiken
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value == " " || value == "")
            {
                throw new ArgumentException($"Name cannot be empty.");
            }
            name = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 15)
            {
                throw new ArgumentException($"Age should be between 0 and 15.");
            }
            age = value;
        }
    }

    public Chiken(string name, int age)
    {
        Name = name;
        Age = age;
    }

    private double productPerDay;

    private void CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                productPerDay = 1.5;
                break;

            case 4:
            case 5:
            case 6:
            case 7:
                productPerDay = 2;
                break;

            case 8:
            case 9:
            case 10:
            case 11:
                productPerDay = 1;
                break;

            default:
                productPerDay = 0.75;
                break;

        }

    }

    public void ProductPerDay()
    {
        CalculateProductPerDay();

        Console.WriteLine($"Chicken {name} (age {age}) can produce {productPerDay} eggs per day.");
    }



}

