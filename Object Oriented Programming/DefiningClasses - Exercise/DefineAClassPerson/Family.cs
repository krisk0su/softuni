using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Family
    {
        private List<Person> listOfPeople = new List<Person>();

        //void AddMember(Person member)) 

        public void AddMember(Person person)
        {
            this.listOfPeople.Add(person);
        }

        public void GetOldestMember()
        {
            var p = this.listOfPeople.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"{p.Name} {p.Age}");
           
        }
}

