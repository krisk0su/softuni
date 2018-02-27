using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    private string gender;

    public string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;

        Age = age;

        Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return "";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        var sound = ProduceSound();

        sb.AppendLine(this.GetType().Name);
        sb.AppendLine($"{this.name} {age} {gender}");
        sb.AppendLine(sound);

        return sb.ToString();
    }
}

