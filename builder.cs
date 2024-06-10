using System;

public class Meal{
    public string burger;
    public string drink;
}
public interface MealBuilder{
    string build_burger();
    string build_drink();
}
public class VegMealBuilder:MealBuilder{
    public string build_burger(){
        return "veg burger";
    }
    public string build_drink(){
        return "cocacola";
    }
}
public class Director{
    public Meal construct(MealBuilder builder){
        Meal ml = new Meal();
        ml.burger = builder.build_burger();
        ml.drink = builder.build_drink();
        return ml;
    }
}
public class Program{
    public static void Main(string[] args){
        Director dr = new Director();
        VegMealBuilder vb = new VegMealBuilder();
        Meal output = dr.construct(vb);
        Console.WriteLine($"{output.burger}{output.drink}");
    }
}