public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 5.0; // base cost of simple coffee
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _decoratedCoffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _decoratedCoffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _decoratedCoffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return _decoratedCoffee.GetCost();
    }
}
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _decoratedCoffee.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return _decoratedCoffee.GetCost() + 1.5; // cost of milk
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _decoratedCoffee.GetDescription() + ", Sugar";
    }

    public override double GetCost()
    {
        return _decoratedCoffee.GetCost() + 0.5; // cost of sugar
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create a simple coffee
        ICoffee myCoffee = new SimpleCoffee();
        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

        // Add milk to the coffee
        myCoffee = new MilkDecorator(myCoffee);
        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

        // Add sugar to the coffee
        myCoffee = new SugarDecorator(myCoffee);
        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

        // Add another layer of milk
        myCoffee = new MilkDecorator(myCoffee);
        Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");
    }
}
