using System;
using System.Collections.Generic;
using System.Text;

public class Student : Human
{
    private string facNum;

    public string FacNum
    {
        get { return this.facNum; }
        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            foreach (var c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            facNum = value;
        }
    }
    public Student(string firstName, string lastName, string facNum)
        : base(firstName, lastName)
    {
        FacNum = facNum;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Faculty number: {facNum}");

        return sb.ToString();
    }
}

