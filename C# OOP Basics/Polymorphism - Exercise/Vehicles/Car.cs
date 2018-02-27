internal class Car : Vehicle
{
    private const double summerIncreasedConsumption = 0.9;

    public Car(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(type, fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        double needFuel = distance * (base.FuelConsumption + summerIncreasedConsumption);

        if (needFuel <= base.FuelQuantity)
        {
            Writer.WriteLine($"{Type} travelled {distance} km");
            base.FuelQuantity -= needFuel;
        }
        else
        {
            Writer.WriteLine($"{Type} needs refueling");
        }
    }

    public override void Refuel(double fuel)
    {
        if (base.FuelQuantity + fuel < 0)
        {
            Writer.WriteLine("Fuel must be a positive number");
            return;
        }
        else if (base.FuelQuantity + fuel > base.TankCapacity)
        {
            Writer.WriteLine("Cannot fit fuel in tank");
        }
        else
        {
            base.FuelQuantity += fuel;
        }
    }

    public override string ToString()
    {
        return $"{Type}: {base.FuelQuantity:F2}";
    }
}