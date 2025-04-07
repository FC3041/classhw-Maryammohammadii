namespace hw;

public interface Icars
{
    string Name { get; }
    double Speed { get; }
    int Capacity { get; }
    void Move();
    void Stop();
}

class Car : Icars
{
    public string Name { get; } = "car";
    public double Speed { get; private set; }
    public int Capacity { get; } = 5;

    public void Move()
    {
        Speed = 100; 
        Console.WriteLine($"{Name} is moving {Speed} km/h");
    }

    public void Stop()
    {
        Speed = 0;
        Console.WriteLine($"{Name} stop");
    }
}

class Bus : Icars
{
    public string Name { get; } ="bus";
    public double Speed { get; private set; }
    public int Capacity { get; } = 25;

    public void Move()
    {
        Speed = 65;
        Console.WriteLine($"{Name} is moving {Speed} km/h");
    }

    public void Stop()
    {
        Speed = 0;
        Console.WriteLine($"{Name} stop");
    }
}

class Train : Icars
{
    public string Name { get; } = "train";
    public double Speed { get; private set; }
    public int Capacity { get; } = 1500;

    public void Move()
    {
        Speed = 250;
        Console.WriteLine($"{Name} is moving {Speed} km/h");
    }

    public void Stop()
    {
        Speed = 0;
        Console.WriteLine($"{Name} stop");
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Icars> cars = new List<Icars>
        {
            new Car(),
            new Bus(),
            new Train()
        };

        foreach (var car in cars)
        {
            Console.WriteLine($"cars: {car.Name}");
            Console.WriteLine($"capacity {car.Capacity} members");
            car.Move();
            car.Stop();
            Console.WriteLine("***********************");
        }
    }
}