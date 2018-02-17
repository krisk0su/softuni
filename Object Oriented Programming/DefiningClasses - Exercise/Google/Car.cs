using System;
using System.Collections.Generic;
using System.Text;

public class Car
{

    public string carModel;

    public double carSpeed;


    public Car(string model, double speed)
    {
        this.carModel = model;

        this.carSpeed = speed;
    }

    public override string ToString()
    {
        if (carModel.Length == 0)
        {
            return "";
        }

        return $"{carModel} {carSpeed} ";
    }
}

