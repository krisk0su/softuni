using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    class Family
    {
        public List<Person> listOfPeople;


        public Family()
        {
            this.listOfPeople = new List<Person>();
        }

        public void AddMember(Person person)
        {
          this.listOfPeople.Add(person);
        }

        public Person GetOldestMember()
        {
            var oldest = this.listOfPeople.Select(x => x.age).Max();
            var index = this.listOfPeople.FindIndex(x => x.age == oldest);
            return this.listOfPeople[index];
        } 
    }

