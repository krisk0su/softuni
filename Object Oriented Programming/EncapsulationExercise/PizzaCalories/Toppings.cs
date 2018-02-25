using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


class Toppings
{
    private string type;

    public string Type
    {
        get { return type; }
        set
        {   //meat veggies, cheese or sauce

            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
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
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    private double CalculateCalories()
    {
        switch (type.ToLower())
        {
            case "meat":
                return 1.2;
              
            case "veggies":

                return 0.8;

            case "cheese":
                return 1.1;
               
            case "sauce":
                return 0.9;
               
            default:
                return 1;
                
        }
    }

    public Toppings(string type, double wight)
    {
        Type = type;

        Weight = wight;
    }

    public double CaloriesPerGram()
    {
        var res = CalculateCalories();

        return weight*2 * res;
    }
}

