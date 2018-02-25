using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
            
        }
    }

    private long money;

    public long Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    private List<Product> productList;

    public List<Product> ProductList
    {
        get { return productList; }
        set
        {
           
            productList = value;
        }
    }

    public Person(string name, long money)
    {
        Name = name;

        Money = money;

        productList = new List<Product>();
    }

}

