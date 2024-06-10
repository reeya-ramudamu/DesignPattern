using System;

public class SingleTon{
    private static SingleTon st;
    //constructor:making it private will prevent it from being called so that object is not created
    private SingleTon(){}
    //object creation through a method :keeping this method static 
    //so that we can call it without creating a object
    public static SingleTon Getsingleton(){
        
        //condition so that it execute only once: checking if the container (st) to which 
        //we are going to store our object is null or not if not null that means object has been created previously
        //so we dont create object and return the value of st only
        if(st == null){
            //object of this class
            st = new SingleTon();
        }
        return st;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        SingleTon st1 = SingleTon.Getsingleton();
        Console.WriteLine(st1.GetHashCode());
        SingleTon st2 = SingleTon.Getsingleton();
        Console.WriteLine(st2.GetHashCode());
    }
}

//key to remember about singleton pattern(we need to prevent the object to be instantiated because we only requirement an object to be created once)
//1. Constructor is private(so you cannot instantiate in a normal fashion )
//2. Object create with the help of the method
//3. Create field to store object is private(so that it is not accesible outside )
