using System;
using System.Collections.Generic;
using System.Text;


    public class Person
    {
        public string name;

        public string date;


        public Person(string input)
        {
            if (input.Contains("/"))
            {
                this.date = input;
                name = "";
            }
            else
            {
                this.name = input;
                date = "";
            }

           
        }

        public Person(string name, string date)
        {
            this.name = name;

            this.date = date;

        }


}

