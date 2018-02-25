using System;
using System.Collections.Generic;
using System.Text;


class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value)  || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

            }

            name = value;
        }
    }

    private Dough dough ;

    public Dough Dough
    {
        set { this.dough = value; }
    }
    private List<Toppings> toppingList = new List<Toppings>();

    public List<Toppings> ToppingList
    {
        get { return toppingList; }

        set
        {
            if (value.Count < 0 || value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");

            }

            toppingList = value;
        }
    }


    public Pizza(string name)
    {
        Name = name;
        
    }

    private double calories;

    public void CalculateCalories()
    {
        calories += dough.Calories;

        foreach (var top in ToppingList)
        {
            calories += top.CaloriesPerGram();
        }

        Console.WriteLine($"{this.name} - {calories:F2} Calories.");
    }

}

