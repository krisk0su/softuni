using System;
using System.Collections.Generic;
using System.Text;


    public class Car
    {
        public string model;

        public Cargo cargo;

        public Engine engine;

        public List<Tire> tires;


        public Car(string model, Cargo cargo, Engine engine, List<Tire> tireList)
        {
            this.model = model;

            this.cargo = cargo;

            this.engine = engine;

            this.tires = new List<Tire>();

            this.tires = tireList;

        }


    }

