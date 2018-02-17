using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    //model, engine, weight and color
    public string model;

    public Engine engine;

    public string weigth;

    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;

        this.engine = engine;

        this.weigth = "n/a";

        this.color = "n/a";
    }

    //with weigth
    public Car(string model, Engine engine, string input) 
    {
        this.model = model;

        this.engine = engine;

        if (double.TryParse(input, out double res))
        {
            this.weigth = res.ToString();
            this.color = "n/a";
        }
        else
        {
            this.color = input;
            this.weigth = "n/a";

        }
    }

    
    //full
    public Car(string model, Engine engine, string weigth , string color)
    {
        this.model = model;

        this.engine = engine;

        this.weigth = weigth;

        this.color = color;
    }


}

