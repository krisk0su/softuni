using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value;
        }
    }


    public Box(double length, double width, double height)
    {
        Length = length;

        Width = width;

        Height = height;
    }


    public void SurfaceArea()
    {
        //2lw + 2lh + 2wh
        var sum = 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        Console.WriteLine($"Surface Area - {sum:F2}"); 
    }
    
    public void LaternalSurface()
    {
        //Lateral Surface Area = 2lh + 2wh
        var sum = 2 * (length * height) + 2*(width * height);
        Console.WriteLine($"Lateral Surface Area - {sum:F2}");
    }

    public void Volume()
    {
        var sum = length * width * height;

        Console.WriteLine($"Volume - {sum:F2}");
    }


}

