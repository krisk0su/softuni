
    class Person
    {
        public string name;
        public int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;

        }

        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }

        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
    }

