using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    public string id;

    public double height;

    public double width;

    public List<double> topLeftCordinates;

    public List<double> botRightCordinates;


    //constructor
    public Rectangle(string id, double height, double width, List<double> cordinates)
    {
        this.id = id;

        this.height = height;

        this.width = width;

        topLeftCordinates = new List<double>();

        topLeftCordinates = cordinates;

        botRightCordinates = new List<double>();

        botRightCordinates.Add(topLeftCordinates[0] + height);

        botRightCordinates.Add(topLeftCordinates[1] + width);
    }

    public bool CheckIntersect(Rectangle rectangle)
    {
        if (topLeftCordinates[0] > rectangle.botRightCordinates[0]
            || topLeftCordinates[1] > rectangle.botRightCordinates[1]
            || botRightCordinates[0] < rectangle.topLeftCordinates[0]
            || botRightCordinates[1] < rectangle.topLeftCordinates[1])
        {
            return false;
        }

        return true;
    }
}

