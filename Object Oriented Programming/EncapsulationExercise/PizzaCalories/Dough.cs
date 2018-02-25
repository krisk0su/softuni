using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;


class Dough
{
    private string flourtype;

    public string Flourtype
    {
        get { return flourtype; }
        set
        {   //be white or wholegrain 

            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourtype = value;
        }
    }

    private string type;

    public string Type
    {
        get { return type; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            type = value;
        }
    }

    private double weight;

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range[1..200].");

            }
            weight = value;
        }
    }

    private double calories;

    public Dough(string flourtype, string type, double weight)
    {
        Flourtype = flourtype;

        Type = type;

        Weight = weight;
    }

    private void CalculateCalories()
    {
        double num1 = 1;


        switch (Flourtype.ToLower())
        {
            case "white":
                num1 = 1.5;
                break;
            case "wholegrain":
                num1 = 1.0;
                break;
        }

        double num2 = 1;


        switch (Type.ToLower())
        {
            case "crispy":
                num2 = 0.9;
                break;
            case "chewy":
                num2 = 1.1;
                break;
            case "homemade":
                num2 = 1.0;
                break;
        }

        this.calories = weight * 2 * num1 * num2;
    }

    public double Calories
    {
        get
        {   CalculateCalories();
            return this.calories;
        }
    }



}

