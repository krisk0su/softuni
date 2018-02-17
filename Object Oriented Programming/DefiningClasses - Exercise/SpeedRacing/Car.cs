using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


    public class Car
    {
       
        public string model;

        public double fuelAmount;

        public double consumptionPerKm;

        public double distanceTravelled;


        public Car(string model, double fuelAmount, double consumptionPerKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.consumptionPerKm = consumptionPerKm;

            distanceTravelled = 0;

        }

        public bool Move(double amountOfKm)
        {
            if (this.fuelAmount / this.consumptionPerKm >= amountOfKm)
            {
                this.distanceTravelled += amountOfKm;

                this.fuelAmount -= amountOfKm * consumptionPerKm;
                return true;
            }

            return false;
        }

    }

