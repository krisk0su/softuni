using System;
using System.Collections.Generic;
using System.Text;


public class DateModifier
{


    public void Calculate(string date1, string date2)
    {
       DateTime firstDate = DateTime.Parse(date1);
        DateTime scondDate = DateTime.Parse(date2);


        Console.WriteLine(Math.Abs((firstDate - scondDate).TotalDays));
    }


}

