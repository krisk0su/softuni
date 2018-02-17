using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    //model, power, displacement and efficiency

    public string model;

    public double power;

    public string dispacement;

    public string efficiency;

    //must

    public Engine(string model, double power)
    {
        this.model = model;

        this.power = power;

        this.dispacement = "n/a";

        this.efficiency = "n/a";

    }

    //+displacement
    public Engine(string model, double power, string input)
    {
        this.model = model;

        this.power = power;

        if (double.TryParse(input, out double res))
        {
            this.dispacement = res.ToString();
            this.efficiency = "n/a";
        }
        else
        {
            this.efficiency = input;
            this.dispacement = "n/a";
        }
    }
    
    //+full
    public Engine(string model, double power, string dispacement, string efiEfficiency)
    {
        this.model = model;

        this.power = power;

        this.dispacement = dispacement;

        this.efficiency = efiEfficiency;
    }



}

