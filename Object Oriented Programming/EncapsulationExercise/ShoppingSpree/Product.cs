﻿using System;
using System.Collections.Generic;
using System.Text;


public class Product
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
           if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }


    private long cost;

    public long Cost
    {
        get { return cost; }
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }


    public Product(string name, long cost)
    {
        Name = name;

        Cost = cost;

    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}

